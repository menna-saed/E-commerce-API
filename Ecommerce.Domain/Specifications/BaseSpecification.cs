using System.Linq.Expressions;
using Ecommerce.Domain.common;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Prodcut;

namespace Ecommerce.Domain.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; private set; }

    public List<Expression<Func<T, object>>> Includes { get; } = [];

    public List<string> IncludeStrings { get; } = [];
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDesc { get; private set; }
    public int? Take { get; private set; } 
    public int? Skip { get;  private set; }
    public bool IsPagingEnabled { get; private set; }


    IReadOnlyList<Expression<Func<T, object>>> ISpecification<T>.Includes => Includes;

    IReadOnlyList<string> ISpecification<T>.IncludeStrings => IncludeStrings;

    protected void ApplyPagintaed (int? pageNumber, int? pageSize)
    {
        Take = pageSize;
        Skip = (pageNumber - 1) * pageSize;
        IsPagingEnabled = true;
    }
    
    protected void Where(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void orderBy(Expression<Func<T, object>>? orderBy)
    {
        OrderBy =  orderBy;
    }

    protected void orderByDesc(Expression<Func<T, object>>? orderByDesc)
    {
        OrderByDesc = orderByDesc;
    }
    protected void Include(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

   
}
