﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using StockManagement.Business.Abstract;
using StockManagement.Business.Concrete;
using StockManagement.Core.Utilities.Security.Jwt;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework;

namespace StockManagement.Business.DependencyResolvers.Autofac
{
    /// <summary>
    /// Buraya Dependency Injection Sınıfları yazılır.
    /// </summary>
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
