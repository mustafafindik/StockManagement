using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Dto
{
    public class CityListDto:IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}
