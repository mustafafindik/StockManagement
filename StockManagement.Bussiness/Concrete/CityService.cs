using StockManagement.Business.Abstract;
using StockManagement.Business.ValidationRules.FluentValidation;
using StockManagement.Core.Aspects.Autofac.Validation;
using StockManagement.Core.Utilities.Results;
using StockManagement.DataAccess.Abstract;
using StockManagement.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using StockManagement.Core.Aspects.Autofac.Caching;
using StockManagement.Core.Aspects.Autofac.Logging;
using StockManagement.Core.Aspects.Autofac.Security;
using StockManagement.Core.Aspects.Autofac.Transaction;
using StockManagement.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

namespace StockManagement.Business.Concrete
{
    /// <summary>
    /// Buradaki Sonuçlar IResult Sınıfından iplement Edilmiş Sonuçları döner.
    /// Eğer içinde data varsa IDataResult , yoksa IResult
    /// </summary>
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        
        [CacheAspect] ///Verileri Cache alır
        public IDataResult<City> GetById(int cityId)
        {
            var query = _cityRepository.Get(p => p.Id == cityId);
            return new SuccessDataResult<City>(query, "Şehir Başarıyla Alındı");

        }

       
        [ValidationAspect(typeof(CityValidator), Priority = 1)] //Gelen Veriyi Validate eder
        [TransactionScopeAspect] //Ekleme İşleminde Hata Olursa Geri alır Db ye Kayıt etmez
        [CacheRemoveAspect("ICityService.Get")] //Yeni veri eklendiği için ICityService.Get Metodlarındalari cacheleri temizler
        public IResult Add(City city)
        {
            _cityRepository.Add(city);
            return new SuccessResult("Şehir Başarıyla Eklendi.");
        }

        [TransactionScopeAspect] //Silme İşleminde Hata Olursa Geri alır Db ye Kayıt etmez
        [CacheRemoveAspect("ICityService.Get")] // veri Silindiğnde için ICityService.Get Metodlarındalari cacheleri temizler
        public IResult Delete(City city)
        {
            _cityRepository.Delete(city);
            return new SuccessResult("Şehir Başarıyla Silindi.");
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]//Gelen Veriyi Validate eder
        [TransactionScopeAspect]//Güncelleme İşleminde Hata Olursa Geri alır Db ye Kayıt etmez
        [CacheRemoveAspect("ICityService.Get")] // veri Güncelleme için ICityService.Get Metodlarındalari cacheleri temizler
        public IResult Update(City city)
        {
            _cityRepository.Update(city);
            return new SuccessResult("Şehir Başarıyla Güncellendi.");
        }

        [CacheAspect]
        [SecuredOperation("Cities.Get",Priority = 1)] //Bu Yetkiye sahip Kullanıcılar Erişebilir.
        [LogAspect(typeof(MsSqlLogger))]
        public IDataResult<List<City>> GetAll()
        {
            var query = _cityRepository.GetAll().ToList();
            return new SuccessDataResult<List<City>>(query, "Şehirler Başarıyla Alındı.");
        }



    }
}
