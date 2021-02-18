using StockManagement.Core.Entities.Concrete;
using System.Collections.Generic;

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
