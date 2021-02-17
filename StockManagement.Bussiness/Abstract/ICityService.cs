using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Utilities.Results;
using StockManagement.Entities.Concrete;

namespace StockManagement.Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
    }
}
