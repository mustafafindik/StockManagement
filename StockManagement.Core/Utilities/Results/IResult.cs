using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement.Core.Utilities.Results
{
    /// <summary>
    ///  Burada İşlem Sonucu Başarılı oldu mu ve duruma göre Mesaj Dönmek için
    ///  sadece get çünkü ctor içinde Set edilecek.
    /// </summary>
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get;  }
    }
}
