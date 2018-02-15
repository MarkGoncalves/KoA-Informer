using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using CCVD.BI;
using CCVD.Core;
using CCVD.Core.DI;
using CCVD.NAT.Common;
using ElemarJR.FunctionalCSharp;
using Microsoft.Extensions.Logging;
using Ninject;
using Serialize.Linq.Serializers;

namespace CCVD.Win.Design.BI
{
    //public delegate void AtualizarDadosHandle();

    //public interface IRepositorio : IRepositorioNat
    //{
    //    new Try<IDummyException, bool> Carga();
    //    new Try<IDummyException, object> ObterPorId(object chave);
    //}

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    [AutoInject(typeof(BaseRepository<,>), typeof(BaseRepository<,>))]
    public class BaseRepository<T, TKey> : IRepositorioNat<T, TKey>, IDisposable//,IRepositorio
        where T : IEntidade<TKey>, new()
    {
        private Expression<Func<T, bool>> _filtro;
        private DataContext _contexto;
        public DataContext Contexto => _contexto ?? (_contexto = IoC.Instancia().Get<DataContext>());

        #region [   Construtor   ]

        public BaseRepository(NatsBaseClient<T, TKey> client,
            ILogger<BaseRepository<T, TKey>> logger)
        {
            Db = client;
            Logger = logger;
            Atualizou += Cache.Armazenar<T, TKey>;

            Db.Atualizou += objeto => Atualizou?.Invoke(objeto);
            Db.Excluiu += objeto => Excluiu?.Invoke(objeto);
        }

        #endregion

        public Expression<Func<T, bool>> Filtro
        {
            get => _filtro;
            set
            {
                Paginas = 0;
                Lista.Clear();

                if (_filtro?.Equals(value) ?? false)
                    return;

                _filtro = value;
            }
        }

        public void Dispose()
        {
            Db = null;
            //Lista = null;
        }

        public Try<IDummyException, bool> Carga(bool cache = false)
        {
            try
            {
                lock (objLock)
                {
                    if (cache)
                    {
                        Lista.Clear();
                        var lista = Cache.Obter<T>().ToList();
                        if (lista != null)
                            Lista.AddRange(lista);
                        return true;
                    }
                    if (Lista.Any())
                        Paginas++;
                    else
                        Paginas = 1;

                    var filtro = new ExpressionSerializer(new JsonSerializer()).SerializeText(Filtro);
                    var paginacao = new Paginar<TKey>
                    {
                        Pagina = Paginas,
                        Ordem = Ordenacao,
                        Filtro = filtro
                    };
                    if (!Paginar)
                        paginacao.Quantidade = -1;

                    ResponseException ex = null;
                    var retorno = false;
                    Db.Listar(paginacao)
                        .Match(
                            _ => ex = new ResponseException
                            {
                                Message = _.Message,
                                StackTrace = _.StackTrace
                            },
                            e =>
                            {
                                if (!Paginar)
                                    Lista.Clear();
                                Cache.ArmazenarLista<T, TKey>(e.Dados);

                                Task.Run(() => EagerLoad(e.Dados));

                                Lista.AddRange(e.Dados);
                                QuantidadeTotal = e.Total;
                                AtualizarDados?.Invoke();
                                retorno = true;
                            });

                    if (ex != null) return ex;
                    return retorno;
                }
            }
            catch (Exception e)
            {
                Paginas--;
                return new ResponseException
                {
                    Message = e.Message,
                    StackTrace = e.StackTrace
                };
            }
        }

        public async Task EagerLoad(IList<T> lista)
        {
            var propLista = typeof(T).GetProperties()
                .Where(a => a.GetCustomAttributes<ListaAttribute>().Any());


            foreach (var propertyInfo in propLista)
            {
                var lst = lista.GroupBy(a => a.GetType().GetProperty(propertyInfo.Name).GetValue(a, null))
                            .Select(a => a.Key);

                var att = propertyInfo.GetCustomAttribute<ListaAttribute>();
                var tipoLista = Type.GetType(att.Classe);

                var neg = Contexto.ObterRepositorio(tipoLista);

                foreach (var valor in lst)
                {
                    if (valor == null)
                        return;

                    neg.ObterPorId(valor);
                    /*      .Match(
                              ex =>ex,
                              ret => e.Value = ((IEntidade)ret).ToDescription());
                      //*/
                }

            }



        }


        public void SetOrdenacao(Expression<Func<T, TKey>> func, SortDirection direction)
        {
            var member = func.Body as MemberExpression;
            if (member == null) return;
            var order = member.Member.Name;
            var dir = direction == SortDirection.Ascending ? "ascending" : "descending";
            Ordenacao = $"{order} {dir}";
        }

        public event SalvarHandle<T, TKey> Atualizou;
        public event SalvarHandle<T, TKey> Excluiu;

        public IList<T> Pesquisar(string pesquisa)
        {
            try
            {
                IList<T> lista = new List<T>();

                var filtro = new ExpressionSerializer(new JsonSerializer()).SerializeText(Filtro);

                var pesquisar = new Pesquisar
                {
                    Termo = pesquisa,
                    Filtro = filtro
                };

                Db.Pesquisar(pesquisar)
                    .Match(
                        _ => throw _,
                        ret =>
                        {
                            lista = ret.Dados;
                            Cache.ArmazenarLista<T, TKey>(lista);
                        }
                    );


                return lista;
            }
            catch (Exception e)
            {
                throw new DesignException("Não foi possível carregar os dados!", e);
            }
        }

        public Try<IDummyException, T> Salvar(T objeto)
        {
            ResponseException ex = null;

            Db.Salvar(objeto)
                .Match(
                    _ => ex = new ResponseException
                    {
                        Message = _.Message,
                        StackTrace = _.StackTrace
                    },
                    e => objeto = e
                );
            if (ex != null) return ex;
            return objeto;
        }

        public Try<IDummyException, string> Excluir(T objeto)
        {
            return Db.Excluir(objeto);
            //.Match(
            //    _ =>  _,
            //    e => e
            //);
        }

        /// <summary>
        /// Obtem o registro buscando primeiro no cache
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        public Try<IDummyException, T> ObterPorId(TKey chave, bool cache = true)
        {
            try
            {
                T objeto = default(T);
                ResponseException ex = null;

                if (cache)
                {
                    objeto = Cache.Obter<T, TKey>(chave);
                    if (objeto != null)
                        return objeto;
                }

                Db.Listar(new Paginar<TKey> { Id = chave, PorId = true })
                  .Match(
                      _ => ex = new ResponseException
                      {
                          Message = _.Message,
                          StackTrace = _.StackTrace
                      },
                      e =>
                      {
                          objeto = e.Dados.FirstOrDefault();
                          if (objeto != null)
                              Cache.Armazenar<T, TKey>(objeto);
                      });

                if (ex != null) return ex;
                return objeto;
            }
            catch (Exception e)
            {
                return new ResponseException
                {
                    Message = e.Message,
                    StackTrace = e.StackTrace
                };
            }
        }

        ~BaseRepository()
        {
            Dispose();
        }

        #region [   Interface Implementations   ]

        IList IRepositorioNat.Pesquisar(string pesquisa)
        {
            return Pesquisar(pesquisa).ToList();
        }

        Try<IDummyException, object> IRepositorioNat.ObterPorId(object chave)
        {
            try
            {
                ResponseException ex = null;
                object retorno = null;

                ObterPorId((TKey)Convert.ChangeType(chave, typeof(TKey)))
                    .Match(
                        _ => ex = new ResponseException
                        {
                            Message = _.Message,
                            StackTrace = _.StackTrace
                        },
                        obj => retorno = obj);
                if (ex != null) return ex;
                return retorno;
            }
            catch (Exception e)
            {
                return new ResponseException
                {
                    Message = e.Message,
                    StackTrace = e.StackTrace
                };
                //return new DesignException("Não foi possível carregar os dados!", e);
            }
        }

        //Try<IDummyException, object> IRepositorio.ObterPorId(object chave)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region [   Propriedades/Eventos   ]

        public event AtualizarDadosHandle AtualizarDados;
        protected ILogger<BaseRepository<T, TKey>> Logger { get; }
        protected NatsBaseClient<T, TKey> Db { get; private set; }
        public int Paginas { get; private set; }
        public bool Paginar { get; set; }
        private object objLock { get; set; } = new object();
        public List<T> Lista { get; } = new List<T>();
        IList IRepositorioNat.Lista => (IList)Lista;

        public int QuantidadeTotal { get; private set; }

        protected string UrlApi { get; } = ConfigurationManager.AppSettings["api"];
        public string ApiPath { get; set; }
        private string _ordenacao = "";

        public string Ordenacao
        {
            get => _ordenacao;
            set
            {
                if (_ordenacao.Equals(value))
                    return;

                _ordenacao = value;
                Paginas = 0;
                Lista.Clear();
            }
        }

        #endregion
    }



    public class DesignException : Exception
    {
        public DesignException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DesignException(string message)
            : base(message)
        {
        }
    }
}