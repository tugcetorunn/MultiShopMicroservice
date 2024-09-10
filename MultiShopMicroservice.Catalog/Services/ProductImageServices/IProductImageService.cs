using MultiShopMicroservice.Catalog.Dtos.ProductImageDtos;

namespace MultiShopMicroservice.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id);
    }
}
