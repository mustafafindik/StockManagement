using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement.Business.Constants
{
    public static  class Messages
    {
        public const string UserRegisteredSuccessfully = "Kullanıcı Başarıyla Kayıt Oldu.";
        public const string UserNotFound = "Kullanıcı Bulunamadı.";
        public const string PasswordIncorrect = "Şifre Hatalı.";
        public const string UserLoginSuccessfully = "Kullanıcı Başarıyla Giriş Yaptı.";
        public const string UserAlreadyExist = "Kullanıcı Zaten Kayıtlı.";
        public const string AccessTokenCreated = "Token Oluştu";

        public const string CitiesGetSuccessfully = "Şehirler Başarıyla Alındı";
        public const string CityGetSuccessfully = "Şehir Başarıyla Alındı";
        public const string CityAddedSuccessfully = "Şehir Başarıyla Kaydedildi";
        public const string CityUpdatedSuccessfully = "Şehir Başarıyla Güncellendi";
        public const string CityDeletedSuccessfully = "Şehir Başarıyla Silindi.";
        public const string CityAlreadyExist = "Şehir Daha Önce Eklenmiş.";
    }
}
