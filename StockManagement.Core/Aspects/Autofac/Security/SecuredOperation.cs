using System;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.Extensions;
using StockManagement.Core.Utilities.Interceptors;
using StockManagement.Core.Utilities.IoC;

namespace StockManagement.Core.Aspects.Autofac.Security
{
    public class SecuredOperation : MethodInterception
    {
        /// <summary>
        ///  User Rollerine Erişmek İçin  IHttpContextAccessor
        /// </summary>
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        ///  Gelen Roller , ile params şeklinde olacağı için , ile ayrılır.
        /// </summary>
        /// <param name="roles">Kullanıcı Rolleri</param>
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceHelper.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        /// <summary>
        /// Yetkilendirme Kontrolü İşlemden önce çalışmalıdır.
        /// Kullanıcı Rolleri alınır.
        /// Daha Sonra Eğer Kulanıcı Rollerinin içinde Operasyon Yetkili rollerin içinde varsa return ile işlem devam eder. yoksa Hata Fırlatılır.
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new System.Exception("Yetkiniz Yok");
        }
    }
}
