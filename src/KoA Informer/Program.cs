using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CCVD.Core;
using Koa.Model;
using KoA_Informer.Properties;
using LiteDB;

namespace KoA_Informer
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists(@"Data.db"))
            {
                File.WriteAllBytes(@"Data.db", Resources.Data);
            }

            DbMapper();
            CriaLeveis();



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        static void CriaLeveis()
        {
            DataBase.Executar<Building>((db, col) =>
            {
                db.Shrink();

                col.FindAll()
                    .ForEach(build =>
                    {
                        //var leveis =
                        //    db.GetCollection<BuildingLevel>()
                        //        .FindAll()
                        //        .Where(a => a.Building.Id == build.Id)
                        //        .ToList();

                        for (var i = 1; i <= 35; i++)
                        {
                            if (db.GetCollection<BuildingLevel>().Exists(a => a.Building.Id == build.Id && a.Level == i)) continue;

                            var level = new BuildingLevel
                            {
                                Building = build,
                                Level = i
                            };

                            db.GetCollection<BuildingLevel>()
                                .Insert(level);

                            build.Levels.Add(level);
                        }

                        col.Update(build);

                    });
            });
        }

        static void DbMapper()
        {
            var mapper = BsonMapper.Global;

            mapper.Entity<Building>()
                .DbRef(x => x.Levels, "BuildingLevel");

            mapper.Entity<BuildingLevel>()
                .DbRef(x => x.Building, "Building")
                .DbRef(x => x.Requirements, "BuildingRequirement")
                .DbRef(x => x.Materials, "MaterialRequirement");

            mapper.Entity<BuildingRequirement>()
                .DbRef(x => x.BuildingLevel, "BuildingLevel")
                .DbRef(x => x.Requirement, "Requirement");

            mapper.Entity<MaterialRequirement>()
                .DbRef(x => x.Material, "Material");
        }


    }

    public static class DataBase
    {
        public static void Executar(Action<LiteDatabase> action)
        {
            using (var db = new LiteDatabase(@"Data.db"))
            {
                action.Invoke(db);
            }
        }

        public static void Executar<T>(Action<LiteDatabase, LiteCollection<T>> action)
        {
            Executar(db =>
            {
                var name = typeof(T).Name;
                var col = db.GetCollection<T>(name);

                action.Invoke(db, col);
            });
        }
    }
}
