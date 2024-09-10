using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservice.Catalog.Dtos.ProductDtos;
using MultiShopMicroservice.Catalog.Entities;
using MultiShopMicroservice.Catalog.Services.BaseService;
using MultiShopMicroservice.Catalog.Settings;

namespace MultiShopMicroservice.Catalog.Services.ProductServices
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IDatabaseSettings _databaseSettings, IMapper _mapper) : base(_databaseSettings, _mapper, _databaseSettings.ProductCollectionName)
        {
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var newProduct = mapper.Map<Product>(createProductDto);
            await collection.InsertOneAsync(newProduct);
        }

        public async Task DeleteProductAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string id)
        {
            var product = await collection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return mapper.Map<GetProductByIdDto>(product);
        }

        public async Task<List<ResultProductDto>> GetProductsAsync()
        {
            var products = await collection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var updProduct = mapper.Map<Product>(updateProductDto);
            await collection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, updProduct);
        }
    }
}
