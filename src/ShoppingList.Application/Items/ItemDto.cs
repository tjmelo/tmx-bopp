namespace ShoppingList.Application.Items;

public sealed record ItemDto(
    Guid Id,
    string Name,
    decimal Quantity,
    string? Unit,
    bool IsChecked,
    DateTime CreatedAt,
    DateTime? UpdatedAt);