namespace MultiShopMicroservice.Catalog.Dtos.ProductDtos
{
    public class GetProductByIdDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
