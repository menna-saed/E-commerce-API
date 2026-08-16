namespace Ecommerce.Domain.Repository;

public interface IUnitOfwork : IDisposable
{
    IProductReposity ProductReposity { get; }
    
    
    Task<int> SaveChangesAsync();
}