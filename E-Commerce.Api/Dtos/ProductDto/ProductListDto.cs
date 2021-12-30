using E_Commerce.Data.Models;

namespace E_Commerce.Api.Dtos.ProductDto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string ProductNames { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public string productType { get; set; }
        public string productBrand { get; set; }
    }
}
