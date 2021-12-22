using E_Commerce.Business.Interfaces;
using E_Commerce.Data.Context;
using E_Commerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Business.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;
        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }
        public async Task<Product> GetProductById(int id)
        {
            return await context.Product.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await context.Product.ToListAsync();
        }
    }
}
