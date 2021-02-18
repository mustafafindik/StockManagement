namespace StockManagement.Core.Utilities.Results
{
    /// <summary>
    /// Burada Eger İşlem başarılı olursa direk bu sınıfı çagırıp Issuccess değeri true olarak işaretlenmiştir.
    /// </summary>
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
