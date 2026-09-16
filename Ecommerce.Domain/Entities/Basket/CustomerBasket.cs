namespace Ecommerce.Domain.Entities.Basket;

public class CustomerBasket
{
    public Guid Id { get; set; }
    
    public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
}
