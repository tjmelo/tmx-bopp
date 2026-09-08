using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Repositories;

namespace ShoppingList.Infrastructure.Persistence.Repositories;

public sealed class ItemRepository : IItemRepository
{
    private readonly ShoppingListDbContext _context;

    public ItemRepository(ShoppingListDbContext context)
    {
        _context = context;
    }

    public async Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Items.FindAsync([id], cancellationToken);
    }

    public async Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Items
            .AsNoTracking()
            .OrderBy(item => item.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Item item, CancellationToken cancellationToken)
    {
        await _context.Items.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Item item, CancellationToken cancellationToken)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(Item item, CancellationToken cancellationToken)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);
    }
}