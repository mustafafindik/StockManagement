using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.CrossCuttingConcerns.Caching;
using StockManagement.Core.CrossCuttingConcerns.Caching.Microsoft;
using StockManagement.Core.Utilities.IoC;

namespace StockManagement.Core.DependencyResolvers
{
    /// <summary>
    /// Normade StartUp'da yazılan servisleri burada çagıryoruz.
    /// </summary>
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
