using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopMicroservice.Catalog.Dtos.ProductDetailDtos;
using MultiShopMicroservice.Catalog.Dtos.ProductDtos;
using MultiShopMicroservice.Catalog.Services.ProductServices;

namespace MultiShopMicroservice.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await productService.CreateProductAsync(createProductDto);
            return Ok("Ürün eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id);
            return Ok("Ürün silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün güncellendi.");
        }
    }
}
