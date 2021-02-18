using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace StockManagement.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        /// <summary>
        /// classAttributes = MethodInterceptionBaseAttribute ve Miras alan tüm Attrubite lari alıyoruz.
        /// methodAttributes = Burada Çalıştırılmaya çalışan Metodun  MethodInterceptionBaseAttribute ve Miras alan tüm Attrubite lari alıyoruz.
        /// </summary>
        /// <param name="type">Aspcect Eklenen Sınıf</param>
        /// <param name="method">Metod Bilgisi</param>
        /// <param name="interceptors"></param>
        /// <returns></returns>
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)!.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            //Çalışma sırası Priority e göre
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
