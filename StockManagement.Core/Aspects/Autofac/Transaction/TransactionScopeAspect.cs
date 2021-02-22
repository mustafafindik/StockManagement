using Castle.DynamicProxy;
using StockManagement.Core.Utilities.Interceptors;
using System.Transactions;

namespace StockManagement.Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); //Dene
                    transactionScope.Complete(); //Olursa comiti al
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose(); //Hata alırsa geri al ve hata fırlat.
                    throw;
                }
            }
        }
    }
}
