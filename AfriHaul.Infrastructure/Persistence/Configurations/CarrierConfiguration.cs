using AfriHaul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AfriHaul.Infrastructure.Persistence.Configurations;

public class CarrierConfiguration : IEntityTypeConfiguration<Carrier>
{
    public void Configure(EntityTypeBuilder<Carrier> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FullName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(150);
        builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(c => c.LicenseNumber).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Country).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Rating).HasPrecision(3, 2);

        builder.HasMany(c => c.Fleet)
               .WithOne(f => f.Carrier)
               .HasForeignKey(f => f.CarrierId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Shipments)
               .WithOne(s => s.Carrier)
               .HasForeignKey(s => s.CarrierId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}