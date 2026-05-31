using AfriHaul.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AfriHaul.Infrastructure.Persistence;

public class AfriHaulDbContext : DbContext
{
    public AfriHaulDbContext(DbContextOptions<AfriHaulDbContext> options)
        : base(options) { }

    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<Carrier> Carriers => Set<Carrier>();
    public DbSet<Shipper> Shippers => Set<Shipper>();
    public DbSet<Fleet> Fleets => Set<Fleet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AfriHaulDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}