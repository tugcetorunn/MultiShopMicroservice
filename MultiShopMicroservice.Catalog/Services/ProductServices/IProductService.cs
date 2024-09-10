using MultiShopMicroservice.Catalog.Dtos.ProductDtos;

namespace MultiShopMicroservice.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetProductsAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetProductByIdDto> GetProductByIdAsync(string id);
    }
}
