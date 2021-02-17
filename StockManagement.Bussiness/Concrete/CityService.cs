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
    public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<City> GetAll()
        {
            return _cityRepository.GetAll().ToList();
            
        }

        IDataResult<List<City>> ICityService.GetAll()
        {
            var query =  _cityRepository.GetAll().ToList();
            return new SuccessDataResult<List<City>>(query,"Şehirler Başarıyla Alındı.");
        }
    }
}
