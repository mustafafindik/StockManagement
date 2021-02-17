using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockManagement.Business.Abstract;
using StockManagement.Core.Utilities.Results;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework;
using StockManagement.Entities.Concrete;

namespace StockManagement.Business.Concrete
{
    /// <summary>
    /// Buradaki Sonuçlar IResult Sınıfından iplement Edilmiş Sonuçları döner.
    /// Eğer içinde data varsa IDataResult , yoksa IResult
    /// </summary>
    public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

   
        public IDataResult<City> GetById(int cityId)
        {
            var query = _cityRepository.Get(p => p.Id == cityId);
            return new SuccessDataResult<City>(query,"Şehir Başarıyla Alındı");

        }

        public IResult Add(City city)
        {
            _cityRepository.Add(city);
            return new SuccessResult("Şehir Başarıyla Eklendi.");
        }

        public IResult Delete(City city)
        {
            _cityRepository.Delete(city);
            return new SuccessResult("Şehir Başarıyla Silindi.");
        }

        public IResult Update(City city)
        {
            _cityRepository.Update(city);
            return new SuccessResult("Şehir Başarıyla Güncellendi.");
        }

        IDataResult<List<City>> ICityService.GetAll()
        {
            var query =  _cityRepository.GetAll().ToList();
            return new SuccessDataResult<List<City>>(query,"Şehirler Başarıyla Alındı.");
        }
    }
}
