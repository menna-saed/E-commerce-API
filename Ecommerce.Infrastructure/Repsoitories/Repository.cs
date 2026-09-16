using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Prodcut;
using Ecommerce.Domain.Repository;
using Ecommerce.Domain.Specifications;
using Ecommerce.Infrastructure.DBcontext;
using Ecommerce.Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Interface.Repsoitories;

public class Repository<T>(AppDBcontext context) : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken ct)
        => await _dbSet
            .ApplySpecification(specification)
            .FirstOrDefaultAsync(ct);

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification, CancellationToken ct)
        => await _dbSet
            .ApplySpecification(specification)
            .ToListAsync(ct);

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
