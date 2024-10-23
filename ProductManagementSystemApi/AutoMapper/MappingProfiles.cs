using AutoMapper;
using ProductManagementSystemApi.Dto;
using ProductManagementSystemApi.Models;

namespace ProductManagementSystemApi.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
