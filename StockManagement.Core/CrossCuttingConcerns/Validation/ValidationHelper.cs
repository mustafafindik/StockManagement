using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace StockManagement.Core.CrossCuttingConcerns.Validation
{
    /// <summary>
    /// Gelen XXX validator ve Obje için Validate işlemi yapar ve valid değilse hata fırlatır.
    /// Burada Ivalidator sizin Bussiness Valitaion altında xxx için yazdğınız Kurallar sınıfu.
    /// entity ise Kullanıcıdan gelen nesne örnegi
    /// </summary>
    public static class ValidationHelper
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
