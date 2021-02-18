using System.Text;

namespace StockManagement.Core.Utilities.Security.Hashing
{
    /// <summary>
    /// Kullanıcıdan Gelen Şifreyi Hashlemek için Kullanılır.
    /// Buarada passwordhash kullanıcı şifresi hashi ve passwordKey de o şifreyi çözecek anahtardır.
    /// buarada HMACSHA512 Criptogrphy ile şifrelenmiştir.
    /// Alttali Metod ise şifreyi dogrulamak için kullanılır. Gelen şifre ile vb de şifreler aynı mı ?
    /// </summary>
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordKey)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordKey)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordKey))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
