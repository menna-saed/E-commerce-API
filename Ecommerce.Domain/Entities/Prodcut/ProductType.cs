using Ecommerce.Domain.Entities.Prodcut;

namespace Ecommerce.Domain.Entities;

public class ProductType :BaseEntity
{
    public string Name { get; set; }=null!;

    public ICollection<Product> Products { get; set; } = [];

    public static ProductType Create(Guid id, string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        if (id == Guid.Empty)
            throw new ArgumentException("Type id is required", nameof(id));

        return new()
        {
            Id = id,
            Name = name
        };
    }
}