using AfriHaul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AfriHaul.Infrastructure.Persistence.Configurations;

public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
{
    public void Configure(EntityTypeBuilder<Shipper> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FullName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Email).IsRequired().HasMaxLength(150);
        builder.Property(s => s.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(s => s.Company).HasMaxLength(150);
        builder.Property(s => s.Country).IsRequired().HasMaxLength(50);

        builder.HasMany(s => s.Shipments)
               .WithOne(s => s.Shipper)
               .HasForeignKey(s => s.ShipperId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}