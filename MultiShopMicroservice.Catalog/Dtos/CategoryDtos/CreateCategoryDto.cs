namespace MultiShopMicroservice.Catalog.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
    }
    // delete işlemi için dto açmamıza gerek yok geriye bir şey dönmeyecek. sadece parametre olarak id göndereceğiz.
}
