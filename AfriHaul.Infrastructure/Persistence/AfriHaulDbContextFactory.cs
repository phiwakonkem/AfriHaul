using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AfriHaul.Infrastructure.Persistence;

public class AfriHaulDbContextFactory : IDesignTimeDbContextFactory<AfriHaulDbContext>
{
    public AfriHaulDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AfriHaulDbContext>();
        optionsBuilder.UseSqlite("Data Source=afrihaul.db");

        return new AfriHaulDbContext(optionsBuilder.Options);
    }
}