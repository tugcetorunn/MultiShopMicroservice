namespace MultiShopMicroservice.Catalog.Dtos.CategoryDtos
{
    public class GetCategoryByIdDto
    {
        // her bir crud işlemi için single responsibility ilkesini ezmemek adına (tek sorumluluk, her sınıf her metod kendi işlemini
        // yapsın) dto lar oluşturuyoruz.
        public string CategoryId { get; set; } 
        public string CategoryName { get; set; }
    }
}
