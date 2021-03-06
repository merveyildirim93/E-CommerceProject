using E_Commerce.Business.Spesifications;
using E_Commerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.SpesificationData
{
    public class SpesificationEvaluator<TEntity> where TEntity:BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpesification<TEntity> spesification)
        {
            var query = inputQuery;
            if (spesification.Criteria != null)
            {
                query = query.Where(spesification.Criteria);
            }
            if(spesification.OrderBy != null)
            {
                query = query.OrderBy(spesification.OrderBy);
            }
            if (spesification.OrderByDescending != null)
            {
                query = query.OrderBy(spesification.OrderByDescending);
            }
            if(spesification.IsPagingEnabled == true)
            {
                query = query.Skip(spesification.Skip).Take(spesification.Take);
            }
            query = spesification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
