using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Specifications;

namespace Ecommerce.Domain.Repository;

public interface IRepository<T>  where T : BaseEntity 
{
    Task<T?> GetByIdAsync(Guid id,CancellationToken ct);
    
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken ct);

    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification, CancellationToken ct);
    
    void Update(T entity);
    
    void Add(T entity);
    
    void Delete(T entity);
    
    void Delete(Guid id);
}