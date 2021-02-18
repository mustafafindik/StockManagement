using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockManagement.Core.Entities.Concrete;
using StockManagement.Core.Extensions;
using StockManagement.Core.Utilities.Security.Encyption;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace StockManagement.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        /// <summary>
        /// burada tokenOptions değerleri Appsetting.Jsondan alınır.
        /// Configuration ise Appsetting.json a ulaşmak için gerekli Sınıf.
        /// </summary>
        private IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        /// <summary>
        /// Buarada Kullanıcı için bir token oluşturulur. Sırayla Key, Credential, token, Handeler ( bunu handle edip string e çevirecek )
        /// Ve Sonunda token ve Son kullanma tarihi döner. Son kullanma tarihi appsettig.jsondaki dk kadar alıp üzerine ekler
        /// </summary>
        /// <param name="user">Kullanıcı</param>
        /// <param name="roles">Rolleri</param>
        /// <returns></returns>
        public AccessToken CreateToken(User user, List<Role> roles)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, roles);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }


        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<Role> roles)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, roles),
                signingCredentials: signingCredentials
            );
            return jwt;
        }


        /// <summary>
        /// Buarada Kullanıcı hakkında gerekli bilgileri token içine gömmek için kullanılır. Email, Name, Roles...
        /// </summary>
        /// <param name="user">kullanıcı</param>
        /// <param name="roles">Kullanıcı Rolleri</param>
        /// <returns></returns>
        private IEnumerable<Claim> SetClaims(User user, List<Role> roles)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(roles.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
