using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace E_Commerce.Business.Spesifications
{
    public interface ISpesification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
    }
}
