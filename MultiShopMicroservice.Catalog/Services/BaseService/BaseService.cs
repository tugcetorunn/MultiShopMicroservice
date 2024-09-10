using AutoMapper;
using MongoDB.Driver;
using MultiShopMicroservice.Catalog.Settings;

namespace MultiShopMicroservice.Catalog.Services.BaseService
{
    public class BaseService<T>
    {
        // db bağlantısı ve collection oluşturmayı her service te tekrar tekrar yazmak yerine generic hale getireceğiz.
        protected readonly IMongoCollection<T> collection;
        protected readonly IMapper mapper;

        public BaseService(IDatabaseSettings _databaseSettings, IMapper _mapper, string _collectionName)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            collection = database.GetCollection<T>(_collectionName);

            mapper = _mapper;
        }
    }
}
