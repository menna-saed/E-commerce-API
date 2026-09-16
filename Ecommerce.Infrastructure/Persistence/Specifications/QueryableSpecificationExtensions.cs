using Ecommerce.Domain.Entities.Prodcut;
using Ecommerce.Domain.Specifications;

namespace Ecommerce.Infrastructure.Persistence.Specifications;

public static class QueryableSpecificationExtensions
{
    public static IQueryable<T> ApplySpecification<T>(
        this IQueryable<T> query,
       
        ISpecification<T> specification)
        where T : BaseEntity
        => SpecificationEvaluator .Apply(query, specification);
}
