using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Domain.Configration;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.ToTable("ProductBrands");

        builder.HasKey(pb => pb.Id);

        builder.Property(pb => pb.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(pb => pb.Name)
            .IsUnique();

        builder.HasMany(pb => pb.Products)
            .WithOne(p => p.ProductBrand)
            .HasForeignKey(p => p.ProductBrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}