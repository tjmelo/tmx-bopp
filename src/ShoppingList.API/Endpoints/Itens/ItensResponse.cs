namespace ShoppingList.API.Endpoints.Itens;

public sealed record ItensResponse(
    Guid Id,
    string Name,
    decimal Quantity,
    string? Unit,
    bool IsChecked,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

public sealed record CreateItensRequest(
    string Name,
    decimal Quantity,
    string? Unit);

public sealed record UpdateItensRequest(
    string Name,
    decimal Quantity,
    string? Unit,
    bool IsChecked);