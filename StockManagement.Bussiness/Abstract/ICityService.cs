using StockManagement.Core.Utilities.Results;
using StockManagement.Entities.Dto;
using System.Collections.Generic;

namespace StockManagement.Business.Abstract
{
    /// <summary>
    /// Buradaki Sonuçlar IResult Sınıfından iplement Edilmiş Sonuçları döner.
    /// Eğer içinde data varsa IDataResult , yoksa IResult
    /// </summary>
    public interface ICityService
    {
        IDataResult<List<CityDto>> GetAll();
        IDataResult<CityDto> GetById(int cityId);
        IResult Add(CityDto cityDto);
        IResult Delete(CityDto cityDto);
        IResult Update(CityDto cityDto);
    }
}
