using AutoMapper;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<City, CityListDto>().ForMember(dest => dest.Id, opt =>
            //{
            //    opt.MapFrom(src => src.Id);
            //}).ForMember(dest => dest.CityName, opt =>
            //{
            //    opt.MapFrom(src => src.CityName);
            //});

            CreateMap<City, CityListDto>();



        }
    }
}
