namespace StockManagement.Core.Utilities.Results
{
    /// <summary>
    ///  DataResult Aynı zamanda bir Result olduğu için Miras alıyor ve Ordaki Issuccess ve mesajı alıyor
    /// Aynı zamanda T Generic Şekilde Data alıyor.
    ///  IDataResult implement edip onun içindeki  imzaların impkement ediyoruz.
    /// </summary>
    /// <typeparam name="T">Buradaki T Generic tründe</typeparam>
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool isSuccess, string message) : base(isSuccess, message)
        {
            Data = data;
        }

        public DataResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
