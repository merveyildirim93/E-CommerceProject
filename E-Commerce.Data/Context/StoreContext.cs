using E_Commerce.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data.Context
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Product> Product { get; set; }
    }
}
