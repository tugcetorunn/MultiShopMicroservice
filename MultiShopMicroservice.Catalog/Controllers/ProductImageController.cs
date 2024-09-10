using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservice.Catalog.Dtos.ProductDtos;
using MultiShopMicroservice.Catalog.Dtos.ProductImageDtos;
using MultiShopMicroservice.Catalog.Services.ProductImageServices;
using MultiShopMicroservice.Catalog.Services.ProductServices;

namespace MultiShopMicroservice.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService productImageService;
        public ProductImageController(IProductImageService _productImageService)
        {
            productImageService = _productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImages()
        {
            var images = await productImageService.GetProductImagesAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var image = await productImageService.GetProductImageByIdAsync(id);
            return Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün resmi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resmi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün resmi güncellendi.");
        }
    }
}
