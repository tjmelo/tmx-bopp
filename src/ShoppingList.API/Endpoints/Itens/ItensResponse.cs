namespace ShoppingList.API.Endpoints.Itens;

public sealed record ItensResponse(
    Guid Id,
    Guid ShoppingListId,
    string Name,
    decimal Quantity,
    string? Unit,
    bool IsChecked,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

public sealed record CreateItensRequest(
    Guid ShoppingListId,
    string Name,
    decimal Quantity,
    string? Unit);

public sealed record UpdateItensRequest(
    string Name,
    decimal Quantity,
    string? Unit,
    bool IsChecked);