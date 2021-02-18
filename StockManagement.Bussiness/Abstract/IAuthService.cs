using StockManagement.Core.Entities.Concrete;
using StockManagement.Core.Utilities.Results;
using StockManagement.Core.Utilities.Security.Jwt;
using StockManagement.Entities.Dto;

namespace StockManagement.Business.Abstract
{
    /// <summary>
    /// Kullanıcı Login ve Register İşlemleri için Bussines Servis Inferface
    /// </summary>
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegister registerDto);
        IDataResult<User> Login(UserLogin loginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
