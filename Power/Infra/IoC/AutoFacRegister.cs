using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Infra.IoC
{
    public static class AutoFacRegister
    {
        public static IServiceProvider Register(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            RegisterBussinessService(builder);
            RegisterInfraServices(builder);

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }


        private static void RegisterInfraServices(ContainerBuilder builder)
        {
            //builder.RegisterType<ToEntityMapperService>().As<IToEntityMapperService>().InstancePerLifetimeScope();

            ////bd
            //builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            //builder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>().SingleInstance();
            //builder.RegisterType<SqlConnectionFactory>().As<ISqlConnectionFactory>().SingleInstance();
            //builder.RegisterType<FactoryModelService>().As<IFactoryModelService>().InstancePerLifetimeScope();

        }

        private static void RegisterBussinessService(ContainerBuilder builder)
        {

        }
    }
}
