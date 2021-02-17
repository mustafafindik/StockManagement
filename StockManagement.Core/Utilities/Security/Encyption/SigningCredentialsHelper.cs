using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace StockManagement.Core.Utilities.Security.Encyption
{
    /// <summary>
    /// Burada gelen Key Değeri , Algoritma ile Credential Oluşturulur
    /// </summary>
    public static class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
