using AutoMapper;
using MultiShopMicroservice.Catalog.Dtos.CategoryDtos;
using MultiShopMicroservice.Catalog.Entities;

namespace MultiShopMicroservice.Catalog.Mapping.CategoryMapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            // db deki entitylerimizi kullanmak yerine abstract bir çözüm olan map leme işlemini yapıyoruz. (entity lerdeki
            // propertyleri dto lardaki propertylerle eşleştireceğiz.)

            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();

        }
    }
}
