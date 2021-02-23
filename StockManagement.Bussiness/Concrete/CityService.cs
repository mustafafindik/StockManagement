using AutoMapper;
using StockManagement.Business.Abstract;
using StockManagement.Business.Constants;
using StockManagement.Business.Helpers;
using StockManagement.Business.ValidationRules.FluentValidation;
using StockManagement.Core.Aspects.Autofac.Caching;
using StockManagement.Core.Aspects.Autofac.Logging;
using StockManagement.Core.Aspects.Autofac.Transaction;
using StockManagement.Core.Aspects.Autofac.Validation;
using StockManagement.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using StockManagement.Core.Utilities.Business;
using StockManagement.Core.Utilities.Results;
using StockManagement.DataAccess.Abstract;
using StockManagement.Entities.Concrete;
using StockManagement.Entities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace StockManagement.Business.Concrete
{
    /// <summary>
    /// Buradaki Sonuçlar IResult Sınıfından iplement Edilmiş Sonuçları döner.
    /// Eğer içinde data varsa IDataResult , yoksa IResult
    /// </summary>
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ISetDateAndUserService _dateAndUserService;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, ISetDateAndUserService dateAndUserService, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _dateAndUserService = dateAndUserService;
            _mapper = mapper;
        }


        [CacheAspect] ///Verileri Cache alır
        //[SecuredOperation("Cities.Get", Priority = 1)] //Bu Yetkiye sahip Kullanıcılar Erişebilir.
        public IDataResult<CityDto> GetById(int cityId)
        {
            var query = _cityRepository.Get(p => p.Id == cityId);
            var cityDto = _mapper.Map<CityDto>(query);
            return new SuccessDataResult<CityDto>(cityDto, Messages.CityGetSuccessfully);

        }


        [ValidationAspect(typeof(CityValidator), Priority = 1)] //Gelen Veriyi Validate eder
        [TransactionScopeAspect] //Ekleme İşleminde Hata Olursa Geri alır Db ye Kayıt etmez
        [CacheRemoveAspect("ICityService.Get")] //Yeni veri eklendiği için ICityService.Get Metodlarındalari cacheleri temizler
        public IResult Add(CityDto cityDto)
        {
            //İş Kuralları BuniessRun ile beraber bağrıllırç
            IResult result = BusinessRules.Run(CityNameExist(cityDto.CityName)); //IResult Dönen Bussiness İşleri verilebilir.İstediğiniz kadar iş verebilriiz.
            if (result != null)
            {
                return result;
            }

            var city = _mapper.Map<City>(cityDto);
            city = (City)_dateAndUserService.ForAdd(city); // Otomatik Olarak BaseEntitydeki alanları doldurur.

            _cityRepository.Add(city);
            return new SuccessResult(Messages.CityAddedSuccessfully);
        }



        [TransactionScopeAspect] //Silme İşleminde Hata Olursa Geri alır Db ye Kayıt etmez
        [CacheRemoveAspect("ICityService.Get")] // veri Silindiğnde için ICityService.Get Metodlarındalari cacheleri temizler
        public IResult Delete(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _cityRepository.Delete(city);
            return new SuccessResult(Messages.CityDeletedSuccessfully);
        }

        [ValidationAspect(typeof(CityValidator), Priority = 1)]//Gelen Veriyi Validate eder
        [TransactionScopeAspect]//Güncelleme İşleminde Hata Olursa Geri alır Db ye Kayıt etmez
        [CacheRemoveAspect("ICityService.Get")] // veri Güncelleme için ICityService.Get Metodlarındalari cacheleri temizler
        public IResult Update(CityDto cityDto)
        {

            var city = _mapper.Map<City>(cityDto);
            city = (City)_dateAndUserService.ForUpdate(city); // Otomatik Olarak BaseEntitydeki alanları doldurur.
            _cityRepository.Update(city, city.Id);
            return new SuccessResult(Messages.CityUpdatedSuccessfully);
        }


         [CacheAspect]
        //[SecuredOperation("Cities.Get", Priority = 1)] //Bu Yetkiye sahip Kullanıcılar Erişebilir.
        public IDataResult<List<CityDto>> GetAll()
        {
            var query = _cityRepository.GetAll().ToList();
            var cityListDto = _mapper.Map<List<CityDto>>(query);
            return new SuccessDataResult<List<CityDto>>(cityListDto, Messages.CitiesGetSuccessfully);
        }


        #region BussinesRules
        private IResult CityNameExist(string cityName)
        {

            var result = _cityRepository.Get(p => p.CityName == cityName) != null;
            if (result)
            {
                return new ErrorResult(Messages.CityAlreadyExist);
            }

            return new SuccessResult();
        }


        #endregion
    }
}
