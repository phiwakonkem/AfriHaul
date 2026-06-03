using AfriHaul.Domain.Interfaces;
using AfriHaul.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AfriHaul.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddDbContext<AfriHaulDbContext>(options =>
            options.UseSqlite("Data Source=afrihaul.db"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}