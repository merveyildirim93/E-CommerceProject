using E_Commerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
