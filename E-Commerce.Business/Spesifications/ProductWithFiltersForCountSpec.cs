using E_Commerce.Business.Spesifications.ProductDto;
using E_Commerce.Data.Models;

namespace E_Commerce.Business.Spesifications
{
    public class ProductWithFiltersForCountSpec : BaseSpesification<Product>
    {
        public ProductWithFiltersForCountSpec(ProductSpecDto dto)
            : base(x =>
            (string.IsNullOrWhiteSpace(dto.Search) || x.ProductNames.ToLower().Contains(dto.Search)) &&
             (!dto.brandId.HasValue || x.BrandId == dto.brandId) && (!dto.typeId.HasValue || x.TypeId == dto.typeId))
        {

        }
    }
}
