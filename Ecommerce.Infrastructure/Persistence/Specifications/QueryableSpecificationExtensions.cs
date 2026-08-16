using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Specifications;

namespace Ecommerce.Interface.Presistence.Specifications;

public static class QueryableSpecificationExtensions
{
    public static IQueryable<T> ApplySpecification<T>(
        this IQueryable<T> query,
       
        ISpecification<T> specification)
        where T : BaseEntity
        => SpecificationEvaluator.Apply(query, specification);
}
