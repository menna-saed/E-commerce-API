using System.Linq.Expressions;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Specifications;

public interface ISpecification<T> where T : BaseEntity
{
    Expression<Func<T, bool>>? Criteria { get; }

    IReadOnlyList<Expression<Func<T, object>>> Includes { get; }

    IReadOnlyList<string> IncludeStrings { get; }
    
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDesc { get; }
    int? Take { get; }
    
    int? Skip { get; }
    
    bool IsPagingEnabled { get; }
}
