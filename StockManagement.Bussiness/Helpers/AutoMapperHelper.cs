using AutoMapper;
using StockManagement.Entities.Concrete;
using StockManagement.Entities.Dto;

namespace StockManagement.Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
