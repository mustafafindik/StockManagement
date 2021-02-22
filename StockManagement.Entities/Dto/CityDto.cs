using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities;
using StockManagement.Entities.Concrete;

namespace StockManagement.Entities.Dto
{
    public class CityDto:BaseEntity,IEntity
    {
        public string CityName { get; set; }
    }
}
