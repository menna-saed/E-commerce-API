using System.Text.Json;
using Ecommerce.Domain.Entities.Basket;
using Ecommerce.Domain.Repository;
using StackExchange.Redis;

namespace Ecommerce.Infrastructure.Repsoitories;

public sealed class BasketRepository (IConnectionMultiplexer connection): IBasketRepository  
{
    
    //in memroy DB
   private readonly IDatabase _database = connection.GetDatabase();
    
    public async Task<CustomerBasket?> GetBasketAsync(Guid id, CancellationToken cancellationToken = default)
    {
        
       // StringGetAsync
   
       var value = await _database.StringGetAsync(id.ToString());
    
      if(value.IsNullOrEmpty)
          return null;
      
      var Basket = JsonSerializer.Deserialize<CustomerBasket>((string)value!);
      if (Basket is null)
          return null;

      return Basket;
    }

    public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(
        CustomerBasket basket,
        CancellationToken cancellationToken = default,
        TimeSpan? timeToLive = null)
    {
        var id = basket.Id.ToString();

        var json = JsonSerializer.Serialize(basket);

        
        //StringSetAsync 
       var res= await _database.StringSetAsync(id, json, timeToLive ?? TimeSpan.FromDays(7));

       return res ? basket : null;
    }

    public async  Task<bool> DeleteBasketAsync(Guid id, CancellationToken cancellationToken = default)
    {
        // KeyDeleteAsync
        
       return await _database.KeyDeleteAsync(id.ToString());
      
    }
}
