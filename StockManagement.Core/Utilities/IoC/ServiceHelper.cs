using Microsoft.Extensions.DependencyInjection;
using System;

namespace StockManagement.Core.Utilities.IoC
{
    public static class ServiceHelper
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
