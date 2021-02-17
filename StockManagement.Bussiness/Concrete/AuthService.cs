using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Business.Abstract;
using StockManagement.Core.Entities.Concrete;
using StockManagement.Core.Utilities.Results;
using StockManagement.Core.Utilities.Security.Hashing;
using StockManagement.Core.Utilities.Security.Jwt;
using StockManagement.Entities.Dto;

namespace StockManagement.Business.Concrete
{
    /// <summary>
    /// Kullanıcı Login ve Register İşlemleri için Bussines Servis 
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserRegister registerDto)
        {
            HashingHelper.CreatePasswordHash(registerDto.Password, out var passwordHash, out var passwordKey);
            var user = new User
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = passwordHash,
                PasswordKey = passwordKey,
                IsActive= true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kullanıcı Kayıt Edildi.");
        }

        public IDataResult<User> Login(UserLogin loginDto)
        {
            var userToCheck = _userService.GetByMail(loginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı Bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordKey))
            {
                return new ErrorDataResult<User>("Şifre Hatalı");
            }

            return new SuccessDataResult<User>(userToCheck, "Başarıyla Giriş Yapıldı.");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı Zaten Var");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetRoles(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token Oluştu.");
        }
    }
}
