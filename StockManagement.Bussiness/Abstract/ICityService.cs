using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Utilities.Results;
using StockManagement.Entities.Concrete;

namespace StockManagement.Business.Abstract
{
    /// <summary>
    /// Buradaki Sonuçlar IResult Sınıfından iplement Edilmiş Sonuçları döner.
    /// Eğer içinde data varsa IDataResult , yoksa IResult
    /// </summary>
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IDataResult<City> GetById(int cityId);
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);
    }
}
