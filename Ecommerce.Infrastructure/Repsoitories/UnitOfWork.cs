using Ecommerce.Domain.Repository;
using Ecommerce.Infrastructure.Configration.DBcontext;

namespace Ecommerce.Interface.Repsoitories;

public class UnitOfWork : IUnitOfwork
{
 
    private readonly AppDBcontext _context;

    public IProductReposity ProductReposity { get; }
    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}