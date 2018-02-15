using System;
using System.Collections;
using System.Collections.Generic;
using CCVD.BI;
using CCVD.Core.Logger;
using CCVD.NAT.Common;
using Microsoft.Extensions.Logging;

namespace CCVD.Win.Design.BI
{
    public class LogSistemasRepository : NatsBase, IEnumerable<string>
    {
        public LogSistemasRepository(ConfigNats config, INatsRequest requestBase, ILogger<LogSistemasRepository> logger)
            : base(config, requestBase, logger)
        {
            Maquina = Environment.MachineName;
        }

        public string Maquina { get; set; }

        public IEnumerable<LogModel> this[string index]
        {
            get
            {
                var resultado = Request<string, List<LogModel>>($"LOG.{Maquina}.LISTA", index);
                if (resultado.StatusCode != 200)
                    throw new Exception(resultado.Exception.Message);
                    //yield return null;
                
                    foreach (var sistema in resultado.Body)
                        yield return sistema;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            var resultado = Request<List<string>>($"LOG.{Maquina}.SISTEMAS");
            foreach (var sistema in resultado.Body)
                yield return sistema;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}