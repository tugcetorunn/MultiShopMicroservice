using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservice.Catalog.Dtos.ProductDetailDtos;
using MultiShopMicroservice.Catalog.Entities;
using MultiShopMicroservice.Catalog.Services.BaseService;
using MultiShopMicroservice.Catalog.Settings;

namespace MultiShopMicroservice.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : BaseService<ProductDetail>, IProductDetailService
    {
        public ProductDetailService(IDatabaseSettings _databaseSettings, IMapper _mapper) : base(_databaseSettings, _mapper, _databaseSettings.ProductDetailCollectionName)
        {
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var newDetail = mapper.Map<ProductDetail>(createProductDetailDto);
            await collection.InsertOneAsync(newDetail);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.DetailId == id);
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string id)
        {
            var detail = await collection.Find<ProductDetail>(x => x.DetailId == id).FirstOrDefaultAsync();
            return mapper.Map<GetProductDetailByIdDto>(detail);
        }

        public async Task<List<ResultProductDetailDto>> GetProductDetailsAsync()
        {
            var details = await collection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDetailDto>>(details);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var updDetail = mapper.Map<ProductDetail>(updateProductDetailDto);
            await collection.FindOneAndReplaceAsync(x => x.DetailId == updateProductDetailDto.DetailId, updDetail);
        }
    }
}
