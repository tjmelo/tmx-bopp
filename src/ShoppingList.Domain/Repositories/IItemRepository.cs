using ShoppingList.Domain.Entities;

namespace ShoppingList.Domain.Repositories;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Item item, CancellationToken cancellationToken = default);
    Task UpdateAsync(Item item, CancellationToken cancellationToken = default);
    Task RemoveAsync(Item item, CancellationToken cancellationToken = default);
}