using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Interface.Presistence.Specifications;

public static class SpecificationEvaluator
{
    public static IQueryable<T>  Apply<T>(IQueryable<T> query, ISpecification<T> specification)
        where T : BaseEntity
    {
        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);

        
        // for loop كاني عملت 
        query = specification.Includes.Aggregate(
            query,
            (current, include) => current.Include(include));

        foreach (var include in specification.IncludeStrings)
            query = query.Include(include);
        
        if(specification.OrderBy is not null)
            query = query.OrderBy(specification.OrderBy);

        if (specification.OrderByDesc is not null)
            query = query.OrderByDescending(specification.OrderByDesc);
        
        
        
        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip ?? 0).Take(specification.Take ?? int.MaxValue);
        }

        return query;
    }
}
