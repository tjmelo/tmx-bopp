using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Application.Items;

namespace ShoppingList.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();

        return services;
    }
}