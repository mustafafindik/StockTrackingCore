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

            //Categories
            CreateMap<SubCategory, SubCategoryListDto>().ForMember(dest => dest.Id, opt =>
            {
                opt.MapFrom(src => src.Id);
            }).ForMember(dest => dest.CategoryName, opt =>
            {
                opt.MapFrom(src => src.SubCategoryName);
            }).ForMember(dest => dest.ParentCategoryid, opt =>
            {
                opt.MapFrom(src => src.CategoryId);
            });
            CreateMap<Category, CategoryListDto>().ForMember(dest => dest.Id, opt =>
            {
                opt.MapFrom(src => src.Id);
            }).ForMember(dest => dest.CategoryName, opt =>
            {
                opt.MapFrom(src => src.CategoryName);
            });

            //Supplier
            CreateMap<Supplier, SupplierListDto>();
            CreateMap<Supplier, SupplierDetailDto>();

            //Customer
            CreateMap<Customer, CustomerListDto>();
            CreateMap<Customer, CustomerDetailDto>();

        }
    }
}
