namespace E_Commerce.Data.Models
{
    public class Product: BaseEntity
    {
       
        public string ProductNames { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public int? TypeId { get; set; }
        public ProductType productType { get; set; }
        public int? BrandId { get; set; }
        public ProductBrand productBrand { get; set; }
    }
}
