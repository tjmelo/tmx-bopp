using ShoppingList.Application.Exceptions;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Repositories;

namespace ShoppingList.Application.Items;

public sealed class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ItemDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetAllAsync(cancellationToken);
        return items.Select(Map).ToList();
    }

    public async Task<ItemDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item is null ? null : Map(item);
    }

    public async Task<ItemDto> CreateAsync(CreateItemCommand command, CancellationToken cancellationToken = default)
    {
        var item = new Item(command.ShoppingListId, command.Name, command.Quantity, command.Unit);
        await _repository.AddAsync(item, cancellationToken);
        return Map(item);
    }

    public async Task<ItemDto> UpdateAsync(Guid id, UpdateItemCommand command, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException(nameof(Item), id);

        item.Rename(command.Name);
        item.SetQuantity(command.Quantity);
        item.SetUnit(command.Unit);

        if (command.IsChecked)
        {
            item.Check();
        }
        else
        {
            item.Uncheck();
        }

        await _repository.UpdateAsync(item, cancellationToken);
        return Map(item);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException(nameof(Item), id);

        await _repository.RemoveAsync(item, cancellationToken);
    }

    private static ItemDto Map(Item item) => new(
        item.Id,
        item.ShoppingListId,
        item.Name,
        item.Quantity,
        item.Unit,
        item.IsChecked,
        item.CreatedAt,
        item.UpdatedAt);
}