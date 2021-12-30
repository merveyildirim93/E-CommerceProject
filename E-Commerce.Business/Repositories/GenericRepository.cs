using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Spesifications;
using E_Commerce.Data.Context;
using E_Commerce.Data.Models;
using E_Commerce.Data.SpesificationData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext context;
        public GenericRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<int> CountAsync(ISpesification<T> spesification)
        {
            return await ApplySpesification(spesification).CountAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpesification<T> spesification)
        {
            return await ApplySpesification(spesification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpesification<T> spesification)
        {
            return await ApplySpesification(spesification).ToListAsync();
        }

        private IQueryable<T> ApplySpesification(ISpesification<T> spesification)
        {
            return SpesificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spesification);
        }
    }
}
