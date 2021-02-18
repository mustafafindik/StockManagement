using Castle.DynamicProxy;
using FluentValidation;
using StockManagement.Core.CrossCuttingConcerns.Validation;
using StockManagement.Core.Utilities.Interceptors;
using System;
using System.Linq;

namespace StockManagement.Core.Aspects.Autofac.Validation
{
    /// <summary>
    /// MethodInterception içindeki OnBefore metodu override edilerek Buarada gerekli işlemler yazılır.
    /// Orda metodların boş olmasının sebebi Her Asprect için farkllı durumlarda çalışacağı içindir.
    /// 
    /// </summary>
    public class ValidationAspect : MethodInterception
    {
        /// <summary>
        /// Burada gelen Type Bir IValidator ınterfacenin referans almış XXXValidator Sınıfı olmalıdır.
        /// İlk olarak gelen Sınıf IValidator referans almıyorsa Hata döner.
        ///  Sorun yoksa Onbefore metodu çalışır. 
        /// </summary>
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception($"Hatalı Validasyon Tipi");
            }

            _validatorType = validatorType;
        }

        /// <summary>
        /// validator :  gelen Type nesnesinden Bir tane İntance üretilir. Bu IValidator diye cast edilir.
        /// _validatorType.BaseType :  Burada gelen XXXValidator Sınınfa T generic olarak alan Sınıf. Örnegin CityValidator , base type olarak City alır.
        /// Tek T aldığı için 0. bizim City Type olur.
        ///
        /// invocation.Arguments => Metod içinde tüm Argmanlar, gelen paramentreler..
        /// içindeki her argmuman için bizim type eşit olanı buluyoruz ve bizim gelen nesne örnegimiz oluyor..
        /// Bunu ve valitatoru Yazdığımız merkez ValidationHelpere gönderiyoruz...
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationHelper.Validate(validator, entity);
            }
        }
    }
}
