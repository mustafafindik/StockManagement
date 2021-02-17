using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement.Core.Utilities.Results
{
    /// <summary>
    ///  Burada IDataResult IResultdaki İşlem Sonucu ve Messajı alır + olarak T data Şekilde veri döner.
    /// </summary>
    /// <typeparam name="T">Bu Sınıfı İmplement Eden Nesnenin Kendisi T Generic</typeparam>
    public interface IDataResult<out T> :IResult
    {
        T Data { get; }
    }
}
