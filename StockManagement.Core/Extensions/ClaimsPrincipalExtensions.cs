using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace StockManagement.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// ClaimsPrincipal Sınıfını extend Ediyoruz.
        /// Yani Genişletme (extra Metodlar).
        ///
        /// claimsPrincipal = extend edilen Metodlar.
        ///  claimType a göre filtreleme yapıyoruz.
        ///
        /// result =  gelen claimtype göre bul ve değerlerini liste olarak döndür.
        ///
        /// 
        /// </summary>
        private static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }



        /// <summary>
        ///  ClaimsPrincipal içindeki Rolleri alıyorz. ve üstteki Medod aracılığı ile bize kullanıcın rolleri döner.
        /// ClaimsPrincipal.ClaimRoles ile roller döner.
        ///
        ///  Bu Genişletme başka özellikler içinde yazılabilr.
        /// </summary>
        /// <param name="claimsPrincipal">ClaimsPrincipal s</param>
        /// <returns></returns>
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }

        public static int ClaimId(this ClaimsPrincipal claimsPrincipal)
        {
            var result = claimsPrincipal?.FindAll(ClaimTypes.NameIdentifier)?.Select(x => x.Value).FirstOrDefault();
            return Int32.Parse(result!);
        }

    }
}
