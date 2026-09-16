using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Prodcut;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations;

internal static class BaseEntityConfigration
{
    public static void Configure<TEntity>(EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        builder.Property(entity => entity.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(entity => !entity.IsDeleted);
    }
}