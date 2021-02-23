using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using StockManagement.Business.Abstract;
using StockManagement.Business.Concrete;
using StockManagement.Business.Helpers;
using StockManagement.Core.Utilities.Interceptors;
using StockManagement.Core.Utilities.Security.Jwt;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework;
using System.Collections.Generic;

namespace StockManagement.Business.DependencyResolvers.Autofac
{
    /// <summary>
    /// Buraya Dependency Injection Sınıfları yazılır.
    /// RegisterAssemblyTypes Aspectler için kullanılıyor.
    /// </summary>
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityService>().As<ICityService>().SingleInstance();
            builder.RegisterType<CityRepository>().As<ICityRepository>().SingleInstance();

            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<SetDateAndUserService>().As<ISetDateAndUserService>();
            builder.RegisterType<AutoMapperHelper>().As<Profile>();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
