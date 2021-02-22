using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.Utilities.Interceptors;
using StockManagement.Core.Utilities.IoC;
using System.Diagnostics;

namespace StockManagement.Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;

        /// <summary>
        ///  Burada Operasyon arasındaki işlemlerin süresini tutmak için  Stopwatch kullanılır.
        /// </summary>
        /// <param name="interval">Kullanıcıdan gelen süre</param>
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceHelper.ServiceProvider.GetService<Stopwatch>();
        }

        /// <summary>
        /// Operasyon Başladığında Süre başlar
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        /// <summary>
        /// Operasyon bittionde Toplam geçen Süre hesaplanır ve Eğer Kullanının verdiği süreden büyükse İşlem uygulanır. Log,Mail..
        /// </summary>
        /// <param name="invocation"></param>

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                var projectReflection = invocation.Method.DeclaringType?.FullName;
                var methodName = invocation.Method.Name;
                var totalSecond = _stopwatch.Elapsed.TotalSeconds;


                Debug.WriteLine($"Performance : {projectReflection}.{methodName}-->{totalSecond}");
            }
            _stopwatch.Reset();
        }
    }
}
