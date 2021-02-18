namespace StockManagement.Core.Utilities.Results
{
    /// <summary>
    /// Burada Eger İşlem başarılı olmassa direk bu sınıfı çagırıp Issuccess değeri false olarak işaretlenmiştir.
    /// </summary>
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}
