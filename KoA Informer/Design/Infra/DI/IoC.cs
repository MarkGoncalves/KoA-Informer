using System;
using System.Linq;
using System.Reflection;
using CCVD.Core.Logger;
using CCVD.NAT.Common;
using CCVD.Win.Design.BI;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Activation;

namespace CCVD.Win.Design.Infra.DI
{
    public class IoC
    {
        private static IKernel Kernel { get; set; }

        public static IKernel Instancia(bool renovar = false)
        {
            if (Kernel != null && !renovar)
                return Kernel;

            Kernel = Core.DI.IoC.Instancia(renovar);
            Registrar();
            return Kernel;
        }

        private static void Registrar()
        {
            Kernel.Bind<ConfigNats>().ToProvider<ConfigNatsProvider>();
            Kernel.Bind<LiteDBLoggerConfiguration>().ToProvider<LiteDBLoggerConfigurationProvider>();

            Kernel.Bind(typeof(ILogger)).To(typeof(LiteDBLogger));
            Kernel.Bind(typeof(ILogger<>)).To(typeof(LiteDBLogger<>))
                .WithConstructorArgument("sistema", Assembly.GetEntryAssembly().GetName().Name);

            Kernel.Bind(typeof(IRepositorioNat)).ToProvider<RepositorioProvider>();
            Kernel.Bind(typeof(IRepositorioNat<,>)).To(typeof(BaseRepository<,>));
        }
    }
    public class RepositorioProvider : Provider<IRepositorioNat>
    {
        protected override IRepositorioNat CreateInstance(IContext context)
        {
            var tipo = context.Parameters.First().GetValue(context, context.Request.Target) as Type;

            var tipoKey = tipo.GetInterfaces()
                .FirstOrDefault(a => a.IsGenericType)
                .GenericTypeArguments.First();

            var tipoRep = typeof(BaseRepository<,>).MakeGenericType(tipo, tipoKey);


            return (IRepositorioNat)context.Kernel.Get(tipoRep);
        }
    }
}


