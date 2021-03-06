﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.CrossCuttingConcerns.Caching;
using StockManagement.Core.CrossCuttingConcerns.Caching.Microsoft;
using StockManagement.Core.Utilities.IoC;
using System.Diagnostics;

namespace StockManagement.Core.DependencyResolvers
{
    /// <summary>
    /// Normade StartUp'da yazılan servisleri burada çagıryoruz.
    /// </summary>
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();

        }
    }
}
