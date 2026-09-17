namespace ShoppingList.Application.Items;

public sealed record ItemDto(
    Guid Id,
    Guid ShoppingListId,
    string Name,
    decimal Quantity,
    string? Unit,
    bool IsChecked,
    DateTime CreatedAt,
    DateTime? UpdatedAt);