using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Core.Utilities.Security.Jwt
{
    /// <summary>
    /// Token Oluşturmak için Bir TokenHelper Interface
    /// </summary>
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Role> roles);
    }
}
