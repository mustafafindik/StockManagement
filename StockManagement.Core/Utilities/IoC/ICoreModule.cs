using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StockManagement.Core.Utilities.IoC
{
    /// <summary>
    /// Gelen servisleri implemete etmek için Interface
    /// </summary>
    public interface ICoreModule
    {
        void Load(IServiceCollection services, IConfiguration configuration);
    }
}
