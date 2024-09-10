using AutoMapper;
using MultiShopMicroservice.Catalog.Dtos.ProductDetailDtos;
using MultiShopMicroservice.Catalog.Entities;

namespace MultiShopMicroservice.Catalog.Mapping.ProductDetailMapping
{
    public class ProductDetailMappingProfile : Profile
    {
        public ProductDetailMappingProfile() 
        {
            CreateMap<ProductDetail, GetProductDetailByIdDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        }
    }
}
