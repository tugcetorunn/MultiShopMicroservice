using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservice.Catalog.Dtos.ProductImageDtos;
using MultiShopMicroservice.Catalog.Entities;
using MultiShopMicroservice.Catalog.Services.BaseService;
using MultiShopMicroservice.Catalog.Settings;

namespace MultiShopMicroservice.Catalog.Services.ProductImageServices
{
    public class ProductImageService : BaseService<ProductImage>, IProductImageService
    {
        public ProductImageService(IDatabaseSettings _databaseSettings, IMapper _mapper) : base(_databaseSettings, _mapper, _databaseSettings.ProductImageCollectionName)
        {
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var newImage = mapper.Map<ProductImage>(createProductImageDto);
            await collection.InsertOneAsync(newImage);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.ImageId == id);
        }

        public async Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id)
        {
            var image = await collection.Find<ProductImage>(x => x.ImageId == id).FirstOrDefaultAsync();
            return mapper.Map<GetProductImageByIdDto>(image);
        }

        public async Task<List<ResultProductImageDto>> GetProductImagesAsync()
        {
            var images = await collection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductImageDto>>(images);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var updImage = mapper.Map<ProductImage>(updateProductImageDto);
            await collection.FindOneAndReplaceAsync(x => x.ImageId == updateProductImageDto.ImageId, updImage);
        }
    }
}
