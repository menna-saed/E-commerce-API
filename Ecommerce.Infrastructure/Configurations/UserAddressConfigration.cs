using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Configurations;

public sealed class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses");

        BaseEntityConfigration.Configure(builder);

        builder.Property(x => x.UserId)
            .IsRequired();

   

        builder.Property(x => x.RecipientFirstName)
            .HasMaxLength(UserAddress.MaxNameLength)
            .IsRequired();

        builder.Property(x => x.RecipientLastName)
            .HasMaxLength(UserAddress.MaxNameLength)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(UserAddress.MaxPhoneLength)
            .IsRequired();

        builder.Property(x => x.Country)
            .HasMaxLength(UserAddress.MaxCountryLength)
            .IsRequired();

        builder.Property(x => x.City)
            .HasMaxLength(UserAddress.MaxCityLength)
            .IsRequired();

        builder.Property(x => x.Street)
            .HasMaxLength(UserAddress.MaxStreetLength)
            .IsRequired();

      
        builder.HasIndex(x => x.UserId);
    }
}