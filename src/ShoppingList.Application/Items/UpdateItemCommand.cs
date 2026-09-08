namespace ShoppingList.Application.Items;

public sealed record UpdateItemCommand(
    string Name,
    decimal Quantity,
    string? Unit,
    bool IsChecked);