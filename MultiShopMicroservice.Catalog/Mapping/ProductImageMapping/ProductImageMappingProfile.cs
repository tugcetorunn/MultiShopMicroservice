using AutoMapper;
using MultiShopMicroservice.Catalog.Dtos.ProductImageDtos;
using MultiShopMicroservice.Catalog.Entities;

namespace MultiShopMicroservice.Catalog.Mapping.ProductImageMapping
{
    public class ProductImageMappingProfile : Profile
    {
        public ProductImageMappingProfile() 
        {
            CreateMap<ProductImage, GetProductImageByIdDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        }
    }
}
