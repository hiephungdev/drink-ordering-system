using DrinkOrderingSystem.Application.Common.Interfaces;
using DrinkOrderingSystem.Domain.Interfaces;
using DrinkOrderingSystem.Infrastructure.Identity;
using DrinkOrderingSystem.Infrastructure.Persistence;
using DrinkOrderingSystem.Infrastructure.Realtime;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrinkOrderingSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<IJwtService, JwtService>();
        services.AddSignalR();
        return services;
    }
}
