using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Domain.Repositories;
using ShoppingList.Infrastructure.Persistence;
using ShoppingList.Infrastructure.Persistence.Repositories;

namespace ShoppingList.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ShoppingListDbContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36))));

        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }
}