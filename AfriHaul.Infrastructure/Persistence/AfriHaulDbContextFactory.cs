using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AfriHaul.Infrastructure.Persistence;

public class AfriHaulDbContextFactory : IDesignTimeDbContextFactory<AfriHaulDbContext>
{
    public AfriHaulDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AfriHaulDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=afrihaul;Username=postgres;Password=030526");

        return new AfriHaulDbContext(optionsBuilder.Options);
    }
}