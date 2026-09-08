using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Infrastructure.Persistence;

public sealed class ShoppingListDbContext : DbContext
{
    public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingListDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}