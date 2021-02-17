using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using StockManagement.Business.Abstract;
using StockManagement.Business.Concrete;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework;

namespace StockManagement.Business.DependencyResolvers.Autofac
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();
        }
    }
}
