using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace StockManagement.Core.Utilities.IoC
{
    /// <summary>
    /// Gelen servisleri implemete etmek için Interface
    /// </summary>
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
