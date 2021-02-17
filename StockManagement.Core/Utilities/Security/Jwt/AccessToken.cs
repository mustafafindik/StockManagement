using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement.Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Token için Sınıf, İçinde Token ve Token süresi tutulur.
    /// </summary>
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
