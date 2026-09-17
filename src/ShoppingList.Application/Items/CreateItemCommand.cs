namespace ShoppingList.Application.Items;

public sealed record CreateItemCommand(
    Guid ShoppingListId,
    string Name,
    decimal Quantity,
    string? Unit = null);