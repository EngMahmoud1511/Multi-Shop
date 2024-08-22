using Autofac;
using AutoMapper;
using Multi_Shop.Data.Data;
using Multi_Shop.Data.Profiles;
using Multi_Shop.Repository.Repository;
using Multi_Shop.Service.Services;

namespace Multi_Shop.App.Config
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register the ShopContext with InstancePerLifetimeScope
            builder.RegisterType<ShopContext>().InstancePerLifetimeScope();

            // Register the generic repository as IRepository with InstancePerLifetimeScope
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            // Register all service types in the same assembly as CustomerService
            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
                 // Register all services by their interfaces
                .InstancePerLifetimeScope();

            // Register AutoMapper configuration
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                // Add your AutoMapper profiles here
                cfg.AddProfile<CustomerProfile>(); // Replace with your actual profile
            })).AsSelf().SingleInstance();

            // Register IMapper
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
