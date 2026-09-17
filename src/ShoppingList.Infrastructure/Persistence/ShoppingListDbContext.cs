using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;
using ShoppingListEntity = ShoppingList.Domain.Entities.ShoppingList;

namespace ShoppingList.Infrastructure.Persistence;

public sealed class ShoppingListDbContext : DbContext
{
    public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<ShoppingListEntity> ShoppingLists => Set<ShoppingListEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingListDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}