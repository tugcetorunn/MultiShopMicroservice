using MultiShopMicroservice.Catalog.Dtos.ProductDetailDtos;

namespace MultiShopMicroservice.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string id);
    }
}
