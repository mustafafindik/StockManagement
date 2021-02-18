using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.CrossCuttingConcerns.Caching;
using StockManagement.Core.Utilities.Interceptors;
using StockManagement.Core.Utilities.IoC;

namespace StockManagement.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        /// <summary>
        /// _duration : Cache Süresi verilmesse 60 
        /// </summary>
        private readonly int _duration;
        private readonly ICacheService _cacheService;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheService = ServiceHelper.ServiceProvider.GetService<ICacheService>();
        }
        /// <summary>
        ///  invocation.Method.ReflectedType?.FullName = Çagrılan Servis adı. Örnegin : CityService
        /// invocation.Method.Name = Çagrılan Metod Adı.Örnegin : GetAll
        /// methodName = invocation.Method.ReflectedType?.FullName.invocation.Method.Name 
        /// arguments = Metoda gelen Paremetreler
        /// key = methodName(paramtreler = null) => Örnek CityService.Get() , CityService.Get(1)
        ///
        ///
        /// Key daha önce Eklenmişse Cache'den çağur.Yoksa Metoda devam et. ve Onu Cache 'ekle
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType?.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheService.IsAdd(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheService.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
