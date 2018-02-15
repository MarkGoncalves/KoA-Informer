using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CCVD.BI;
using CCVD.Core;
using CCVD.Design.DI;
using CCVD.NAT.Common;
using ElemarJR.FunctionalCSharp;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Parameters;
using Serialize.Linq.Serializers;

namespace CCVD.Design.BI
{
    [AutoInject(typeof(DataContext), typeof(DataContext))]
    public class DataContext
    {
        public BaseRepository<T, TKey> ObterRepositorio<T, TKey>()
            where T : IEntidade<TKey>, new()
        {
            return IoC.Instancia().Get<BaseRepository<T, TKey>>();
        }

        public IRepositorio ObterRepositorio(Type tipo)
        {
            return IoC.Instancia().Get<IRepositorio>(new ConstructorArgument("tipo", tipo));
        }

        public DbSet<T, TKey> Set<T, TKey>()
            where T : IEntidade<TKey>, new()
        {
            return IoC.Instancia().Get<DbSet<T, TKey>>();
        }

        public ActionSet<T> Set<T>()
            where T : IAcao
        {
            return IoC.Instancia().Get<ActionSet<T>>();
        }
    }

    public class DbSet<T, TKey> //IRepositorio, IDisposable
        where T : IEntidade<TKey>, new()
    {
        #region [   Construtores   ]

        public DbSet(NatsBaseClient<T, TKey> client,
            ILogger<DbSet<T, TKey>> logger)
        {
            Logger = logger;
            Db = client;
        }

        #endregion

        #region [   Propriedades   ]

        protected ILogger<DbSet<T, TKey>> Logger { get; }
        public NatsBaseClient<T, TKey> Db { get; }
        public Expression<Func<T, bool>> Filtro { get; set; }

        #endregion
    }

    public class ActionSet<T>
    {
        #region [   Construtores   ]

        public ActionSet(NatsClient<T> client,
            ILogger<ActionSet<T>> logger)
        {
            Logger = logger;
            Db = client;
        }

        #endregion

        #region [   Propriedades   ]

        protected ILogger<ActionSet<T>> Logger { get; }
        public NatsClient<T> Db { get; }
        public Expression<Func<T, bool>> Filtro { get; set; }

        #endregion
    }

    public static class RepositorioExt
    {
        public static DbSet<T, TKey> Where<T, TKey>(this DbSet<T, TKey> dbSet, Expression<Func<T, bool>> filtro)
            where T : IEntidade<TKey>, new()
        {
            dbSet.Filtro = dbSet.Filtro == null
                ? filtro
                : dbSet.Filtro.And(filtro);
            return dbSet;
        }

        public static IEnumerable<T> Select<T, TKey>(this DbSet<T, TKey> dbSet)
            where T : IEntidade<TKey>, new()
        {
            var filtro = new ExpressionSerializer(new JsonSerializer()).SerializeText(dbSet.Filtro);

            var paginacao = new Paginar<TKey>
            {
                Quantidade = -1,
                Filtro = filtro
            };

            IList<T> lista = null;

            dbSet.Db.Listar(paginacao)
                .Match(
                    _ => throw new DesignException(_.Message),
                    e => { lista = e.Dados; });

            foreach (var a in lista)
                yield return a;
        }

        public static void Salvar<T, TKey>(this DbSet<T, TKey> dbSet, T objeto)
            where T : IEntidade<TKey>, new()
        {

            dbSet.Db.Salvar(objeto)
                .Match(
                    _ => throw new DesignException(_.Message),
                    e => { objeto = e; });

        }

        public static Try<IDummyException, T1> Run<T, T1>(this ActionSet<T> actionSet, Expression<Func<T, T1>> acao)
        {
            ResponseException ex = null;
            var resultado = default(T1);

            actionSet.Db.Run(acao)
                .Match(
                    _ =>
                        ex = new ResponseException
                        {
                            Message = _.Message,
                            StackTrace = _.StackTrace
                        },
                    ret => resultado = ret
                );

            if (ex != null)
                return ex;

            return resultado;
        }

        #region [   Bulk Actions   ]

        public static void BulkInsert<T, TKey>(this DbSet<T, TKey> dbSet, IEnumerable<T> dados)
            where T : IEntidade<TKey>, new()
        {
            dados.ForEach(a => { dbSet.Db.Salvar(a); });
        }

        public static void BulkDelete<T, TKey>(this DbSet<T, TKey> dbSet, IEnumerable<T> dados)
            where T : IEntidade<TKey>, new()
        {
            dados.ForEach(a => dbSet.Db.Excluir(a));
        }

        public static void BulkUpdate<T, TKey>(this DataContext context, IEnumerable<T> lista, Action<T> acao)
            where T : IEntidade<TKey>, new()
        {
            var rep = context.ObterRepositorio<T, TKey>();

            lista.ForEach(a =>
            {
                acao.Invoke(a);

                rep.Salvar(a)
                    .Match(
                        ex => throw new DesignException(ex.Message),
                        ret => ret);
            });
        }

        public static void BulkUpdate<T, TKey>(this DbSet<T, TKey> dbSet, params KeyValuePair<string, object>[] args)
            where T : IEntidade<TKey>, new()
        {
            var filtro = new ExpressionSerializer(new JsonSerializer()).SerializeText(dbSet.Filtro);

            var action = new BulkParam
            {
                Acao = args,
                Filtro = filtro
            };

            dbSet.Db.BulkUpdate(action);
        }

        #endregion
    }
}