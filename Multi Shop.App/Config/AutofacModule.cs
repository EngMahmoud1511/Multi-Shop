using Autofac;
using AutoMapper;
using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Multi_Shop.Data.Data;
using Multi_Shop.Data.Profiles;
using Multi_Shop.Repository.Repository;
using Multi_Shop.Service.Services.Sevices.Class;

namespace Multi_Shop.App.Config
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopContext>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly).AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
                .InstancePerLifetimeScope();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppProfile>();
            })).AsSelf().SingleInstance();

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();

           
        }
    }
}
