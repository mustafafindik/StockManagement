using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using StockManagement.Core.Entities.Concrete;
using StockManagement.Entities.Concrete;
using StockManagement.Entities.Dto;

namespace StockManagement.Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<City, CityListDto>().ReverseMap();
        }
    }
}
