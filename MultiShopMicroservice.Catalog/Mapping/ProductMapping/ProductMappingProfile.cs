using AutoMapper;
using MultiShopMicroservice.Catalog.Dtos.ProductDtos;
using MultiShopMicroservice.Catalog.Entities;

namespace MultiShopMicroservice.Catalog.Mapping.ProductMapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<Product, GetProductByIdDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
        }
    }
}
