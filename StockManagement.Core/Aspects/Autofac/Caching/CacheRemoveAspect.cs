using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.CrossCuttingConcerns.Caching;
using StockManagement.Core.Utilities.Interceptors;
using StockManagement.Core.Utilities.IoC;

namespace StockManagement.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly string _pattern;
        private readonly ICacheService _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheService>();
        }

        /// <summary>
        /// İşlem Başarılı olursa paterndeki verilen key değerine ait cache silinir.
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
