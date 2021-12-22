using E_Commerce.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<IReadOnlyList<Product>> GetProducts();
    }
}
