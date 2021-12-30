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
        public ProductSpecification()
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
        }

        public ProductSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
        }
    }
}
