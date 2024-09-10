using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShopMicroservice.Catalog.Entities
{
    public class Category
    {
        // MongoDB.Bson ve MongoDB.Driver ı nugetten yüklüyoruz.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } // mongodb ilişkisel bir veritabanı sistemi olmadığı için id yi string şeklinde tutuyoruz.
        public string CategoryName { get; set; }
    }
}
