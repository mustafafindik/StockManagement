using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement.Core.Utilities.Results
{
    public class Result:IResult
    {
        /// <summary>
        ///  Burada Eğer Kullaınıcı Hem Sonucun Durumunu Hemde Mesaj göndermek isterse.
        ///  buraffa : this(isSuccess) aşğıdki set edilmiş değerden al demek.
        /// </summary>
        /// <param name="isSuccess">İşlem Başarılı mı?</param>
        /// <param name="message">İşlem Sonucunda Vermek İstediğiniz Mesaj</param>
        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }

        /// <summary>
        ///  Burada Sadece İşlem Sonucunu göndermek için bu ctor kullanılır.
        /// </summary>
        /// <param name="isSuccess">İşlem Başarılı mı?</param>
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
