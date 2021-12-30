using E_Commerce.Business.Spesifications.ProductDto;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Spesifications
{
    public class ProductSpecification : BaseSpesification<Product>
    {
        public ProductSpecification(ProductSpecDto dto)
            :base(x => 
            (string.IsNullOrWhiteSpace(dto.Search) || x.ProductNames.ToLower().Contains(dto.Search)) &&
            (!dto.brandId.HasValue || x.BrandId == dto.brandId) && (!dto.typeId.HasValue || x.TypeId == dto.typeId))
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
            //AddOrderBy(x => x.ProductNames);
            if (!string.IsNullOrWhiteSpace(dto.sort))
            {
                switch (dto.sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.ProductNames);
                        break;
                }
            }

            ApplyPaging(dto.PageSize * (dto.PageIndex - 1), dto.PageSize);
        }

        public ProductSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
            AddOrderBy(x => x.ProductNames);
        }
    }
}
