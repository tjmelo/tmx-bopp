namespace ShoppingList.Application.Items;

public sealed record CreateItemCommand(
    string Name,
    decimal Quantity,
    string? Unit = null);