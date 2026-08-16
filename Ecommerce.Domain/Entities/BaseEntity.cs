namespace Ecommerce.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public DateTimeOffset CreatedAt { get;  set; }

    public DateTimeOffset? UpdatedAt { get;  set; }

    public bool IsDeleted { get; private set; }
    
    public void MarkDeleted()
    {
        IsDeleted = true;
        UpdatedAt = DateTimeOffset.Now;
    }
}