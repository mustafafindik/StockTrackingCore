using AutoMapper;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //city
            CreateMap<City, CityListDto>();
            CreateMap<City, CityDetailDto>();

            //warehouse
            CreateMap<Warehouse, WarehouseListDto>().ForMember(dest => dest.City, opt =>
            {
                opt.MapFrom(src => src.City.CityName);
            });
            CreateMap<Warehouse, WarehouseDetailDto>().ForMember(dest => dest.City, opt =>
            {
                opt.MapFrom(src => src.City.CityName);
            });

            //Unit
            CreateMap<Unit, UnitListDto>();
            CreateMap<Unit, UnitDetailDto>();

            //VatRate
            CreateMap<VatRate, VatRateListDto>();
            CreateMap<VatRate, VatRateDetailDto>();

        }
    }
}
