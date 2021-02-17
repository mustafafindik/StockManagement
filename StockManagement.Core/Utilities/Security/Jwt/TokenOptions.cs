using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement.Core.Utilities.Security.Jwt
{

    /// <summary>
    /// Tokende kullanılacak ayarlar. Appsetingsjson dan alınıp set edilmesi için.
    /// </summary>
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
