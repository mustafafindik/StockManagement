using StockManagement.Core.Utilities.Results;

namespace StockManagement.Core.Utilities.Business
{
    /// <summary>
    /// Gelen IResult Dönen İş kurallarını Döner eger içlerinden birisinde Issuccess false ile Mesajı döner.
    /// 
    /// </summary>
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.IsSuccess)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
