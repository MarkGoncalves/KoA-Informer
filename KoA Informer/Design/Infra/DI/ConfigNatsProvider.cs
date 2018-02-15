using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using CCVD.BI;
using CCVD.Core;
using CCVD.Core.Logger;
using CCVD.NAT.Common;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Activation;

namespace CCVD.Win.Design.Infra.DI
{
    public class ConfigNatsProvider : Provider<ConfigNats>
    {
        protected override ConfigNats CreateInstance(IContext context)
        {

            var sessao = context.Kernel.Get<INatsRequest>();
            var hosts = string.Empty;
            switch (sessao.ModoOperacao)
            {
                case ModoOperacao.Producao:
                    hosts= ConfigurationManager.AppSettings["Hosts"];
                    break;
                case ModoOperacao.Homologacao:
                    hosts = ConfigurationManager.AppSettings["Hosts.Homolog"];
                    break;
                case ModoOperacao.Teste:
                    hosts = ConfigurationManager.AppSettings["Hosts.Debug"];
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //var hosts = Debugger.IsAttached
            //    ? ConfigurationManager.AppSettings["Hosts.Debug"]
            //    : ConfigurationManager.AppSettings["Hosts"];

            var config = new ConfigNats
            {
                Hosts = hosts
            };

            if (int.TryParse(ConfigurationManager.AppSettings["TimeOut"], out int timeout))
                config.TimeOut = timeout;

            return config;
        }
    }

    public class LiteDBLoggerConfigurationProvider : Provider<LiteDBLoggerConfiguration>
    {
        public static string PathApp
        {
            get
            {
                var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // Combine the base folder with your specific folder....
                var specificFolder = Path.Combine(folder, "Granito.Net");

                // Check if folder exists and if not, create it
                if (!Directory.Exists(specificFolder))
                    Directory.CreateDirectory(specificFolder);

                return specificFolder;
            }
        }

        private static LiteDBLoggerConfiguration _instancia;

        protected override LiteDBLoggerConfiguration CreateInstance(IContext context)
        {
            if (_instancia == null)
            {
                var hosts = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                    .SectionGroups["Logging"];

                var leveis =
                    ConfigurationManager.GetSection(hosts.Sections["LogLevel"].SectionInformation.SectionName) as
                        NameValueCollection;
                var logLevel = new Dictionary<string, LogLevel>();
                leveis.AllKeys
                    .ForEach(
                        a => logLevel.Add(a, (LogLevel)Enum.Parse(typeof(LogLevel), leveis[a])));

                var diasLog =
                (ConfigurationManager.GetSection(hosts.Sections["Config"].SectionInformation.SectionName) as
                    NameValueCollection)["DiasLog"];

                var retorno = new LiteDBLoggerConfiguration
                {
                    DataBase = PathApp,
                    LogLevel = logLevel,
                };

                if (diasLog != null)
                    retorno.DiasLog = int.Parse(diasLog);
                _instancia = retorno;
            }
            return _instancia;
        }
    }
}