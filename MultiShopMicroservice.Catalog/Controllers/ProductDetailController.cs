using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservice.Catalog.Dtos.ProductDetailDtos;
using MultiShopMicroservice.Catalog.Dtos.ProductDtos;
using MultiShopMicroservice.Catalog.Services.ProductDetailServices;
using MultiShopMicroservice.Catalog.Services.ProductServices;

namespace MultiShopMicroservice.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;
        public ProductDetailController(IProductDetailService _productDetailService)
        {
            productDetailService = _productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        {
            var details = await productDetailService.GetProductDetailsAsync();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var detail = await productDetailService.GetProductDetailByIdAsync(id);
            return Ok(detail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı güncellendi.");
        }
    }
}
