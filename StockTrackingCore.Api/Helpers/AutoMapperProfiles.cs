using AutoMapper;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
             
            CreateMap<City, CityListDto>();
            CreateMap<City, CityDetailDto>();


            CreateMap<Warehouse, WarehouseListDto>().ForMember(dest => dest.City, opt =>
            {
                opt.MapFrom(src => src.City.CityName);
            });


        }
    }
}
