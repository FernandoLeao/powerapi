using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Power.Infra.DataBase.Connection;
using Power.Repository;
using Power.Services;
using System;

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
            //bd
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>().SingleInstance();
            builder.RegisterType<SqlConnectionFactory>().As<ISqlConnectionFactory>().SingleInstance();
        }

        private static void RegisterBussinessService(ContainerBuilder builder)
        {
            builder.RegisterType<DistribuirCargaService>().As<IDistribuirCargaService>().InstancePerLifetimeScope();
            builder.RegisterType<FileService>().As<IFileService>().InstancePerLifetimeScope();
            builder.RegisterType<EquipamentoService>().As<IEquipamentoService>().InstancePerLifetimeScope();

        }
    }
}
