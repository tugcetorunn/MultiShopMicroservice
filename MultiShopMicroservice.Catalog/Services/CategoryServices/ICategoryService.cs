using MultiShopMicroservice.Catalog.Dtos.CategoryDtos;

namespace MultiShopMicroservice.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id);
    }
}
