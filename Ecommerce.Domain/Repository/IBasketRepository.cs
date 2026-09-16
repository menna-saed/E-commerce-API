using Ecommerce.Domain.Entities.Basket;

namespace Ecommerce.Domain.Repository;

public interface IBasketRepository
{
    Task<CustomerBasket?> GetBasketAsync (Guid id  , CancellationToken cancellationToken =default);
    
    Task<CustomerBasket?> CreateOrUpdateBasketAsync (CustomerBasket basket,CancellationToken cancellationToken=default ,TimeSpan? timeToLive =default );
    
    
    Task<bool> DeleteBasketAsync (Guid id  , CancellationToken cancellationToken=default);

}
