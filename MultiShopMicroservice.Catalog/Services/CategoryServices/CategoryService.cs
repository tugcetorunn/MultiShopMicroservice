using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservice.Catalog.Dtos.CategoryDtos;
using MultiShopMicroservice.Catalog.Entities;
using MultiShopMicroservice.Catalog.Services.BaseService;
using MultiShopMicroservice.Catalog.Settings;

namespace MultiShopMicroservice.Catalog.Services.CategoryServices
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IDatabaseSettings _databaseSettings, IMapper _mapper) : base(_databaseSettings, _mapper, _databaseSettings.CategoryCollectionName)
        {
            // collectionName parametresini ctor a yazdığımızda DI sistemi tarafından otomatik olarak enjekte edilmeye
            // çalışılması sebepli hata alıyoruz. Ancak, DI sistemi doğrudan bir string türünü enjekte edemez, çünkü
            // nasıl çözüleceğini bilemez.Bu sorunu çözmek için, collectionName değerini doğrudan servise DI sırasında
            // sağlıyoruz. (base(_databaseSettings, _mapper, _databaseSettings.CategoryCollectionName))
            // Hata : System.AggregateException: 'Some services are not able to be constructed (Error while validating the service descriptor
            // 'ServiceType: MultiShopMicroservice.Catalog.Services.ProductServices.IProductService Lifetime: Scoped ImplementationType:
            // MultiShopMicroservice.Catalog.Services.ProductServices.ProductService': Unable to resolve service for type 'System.String'
            // while attempting to activate 'MultiShopMicroservice.Catalog.Services.ProductServices.ProductService'.)
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            // async : bloklamayan kod -> kesintiye uğramayan, devamlı
            var newCat = mapper.Map<Category>(createCategoryDto); // dto dan entity ye
            await collection.InsertOneAsync(newCat);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id)
        {
            var cat = await collection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
            return mapper.Map<GetCategoryByIdDto>(cat); // entity den dto ya
        }

        public async Task<List<ResultCategoryDto>> GetCategoriesAsync()
        {
            var cats = await collection.Find(x => true).ToListAsync(); // Find(x => true) tüm kategorileri getirmeye yarar.
            return mapper.Map<List<ResultCategoryDto>>(cats); // entity den dto ya
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var updCatDto = mapper.Map<Category>(updateCategoryDto);
            await collection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, updCatDto);
        }
    }
}
