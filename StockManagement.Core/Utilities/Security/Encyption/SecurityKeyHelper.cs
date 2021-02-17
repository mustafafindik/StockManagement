using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace StockManagement.Core.Utilities.Security.Encyption
{
    /// <summary>
    /// Burada Gelen Key Encode edilir. SymmetricSecurityKey 
    /// </summary>
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
