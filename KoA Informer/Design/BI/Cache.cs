using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CCVD.BI;
using CCVD.Core;
using LiteDB;
using FileMode = LiteDB.FileMode;

namespace CCVD.Win.Design.BI
{
    public static class Cache
    {
        private static readonly ConnectionString ConnectionString;

        static Cache()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            var specificFolder = Path.Combine(folder, "Granito.Net");
            ConnectionString = new ConnectionString(Path.Combine(specificFolder, "CCVD.Cache.db"))
            {
                Mode = FileMode.Shared,
                Journal = true
            };

            AppDomain.CurrentDomain.ProcessExit += (sender, args) =>
            {
                if (File.Exists(ConnectionString.Filename))
                    File.Delete(ConnectionString.Filename);
            };

            if (File.Exists(ConnectionString.Filename))
                File.Delete(ConnectionString.Filename);
        }

        public static T Obter<T, TKey>(TKey chave)
            where T : IEntidade<TKey>, new()
        {
            try
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var logDb = db.GetCollection<T>(typeof(T).FullName.Replace(".", "_"));
                    var sanit = logDb.FindOne(a => a.Codigo.Equals(chave));
                    return sanit;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }

        public static IEnumerable<T> Obter<T>()
        {
            try
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var logDb = db.GetCollection<T>(typeof(T).FullName.Replace(".", "_"));
                    var retorno = logDb.FindAll();
                    return retorno;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static void ArmazenarLista<T, TKey>(IList<T> dados)
            where T : IEntidade<TKey>, new()
        {
            Task.Run(() =>
            {
                try
                {
                    lock (ConnectionString)
                    {
                        using (var db = new LiteDatabase(ConnectionString))
                        {
                            //var mapper = BsonMapper.Global;
                            //mapper.Entity<T>()
                            //    .Id(x => x.Codigo);

                            try
                            {
                                var logDb = db.GetCollection<T>(typeof(T).FullName.Replace(".", "_"));
                                dados.ForEach(a => logDb.Delete(b => b.Codigo.Equals(a.Codigo)));

                                logDb.InsertBulk(dados);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        public static void Armazenar<T, TKey>(T dados)
            where T : IEntidade<TKey>, new()
        {
            try
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    if (typeof(T).GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Any(i => i.GetGenericTypeDefinition() == typeof(IEntidade<>)))
                    {
                        var mapper = BsonMapper.Global;
                        mapper.Entity<T>()
                            .Id(a => a.Codigo);
                        //mapper.SetAutoId(dados, db.Engine, "Codigo");
                    }

                    //using (var trans1 = db.BeginTrans())
                    {
                        try
                        {
                            var logDb = db.GetCollection<T>(typeof(T).FullName.Replace(".", "_"));

                            logDb.Delete(b => b.Codigo.Equals(dados.Codigo));

                            logDb.Insert(dados);

                            //trans1.Commit();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            //trans1.Rollback();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
