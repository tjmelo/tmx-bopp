namespace ShoppingList.Application.Items;

public interface IItemService
{
    Task<IReadOnlyList<ItemDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ItemDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ItemDto> CreateAsync(CreateItemCommand command, CancellationToken cancellationToken = default);
    Task<ItemDto> UpdateAsync(Guid id, UpdateItemCommand command, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}