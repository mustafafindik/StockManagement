using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.Utilities.IoC;

namespace StockManagement.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection collection,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(collection);
            }

            return ServiceHelper.Create(collection);
        }
    }
}
