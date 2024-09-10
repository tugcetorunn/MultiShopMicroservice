using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShopMicroservice.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DetailId { get; set; }
        public string Description { get; set; } // teknik özellikler vs.
        public string Information { get; set; } // garanti süresi ve kapsamı, servis imkanı ve yeri, kullanım talimatları vs.
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
