using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Items;

namespace ShoppingList.API.Endpoints.Itens;

public static class ItensEndpoint
{
    public static IEndpointRouteBuilder MapItensEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/itens")
            .WithTags("Itens");

        group.MapGet("/", GetAllAsync)
            .WithName("GetItens")
            .WithSummary("Lista todos os itens")
            .WithDescription("Retorna todos os itens da lista de compras.")
            .Produces<List<ItensResponse>>(StatusCodes.Status200OK);

        group.MapGet("/{id:guid}", GetByIdAsync)
            .WithName("GetItemById")
            .WithSummary("Obtém um item pelo id")
            .WithDescription("Retorna o item com o identificador informado.")
            .Produces<ItensResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

        group.MapPost("/", CreateAsync)
            .WithName("CreateItem")
            .WithSummary("Cria um novo item")
            .WithDescription("Adiciona um novo item à lista de compras.")
            .Accepts<CreateItensRequest>("application/json")
            .Produces<ItensResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        group.MapPut("/{id:guid}", UpdateAsync)
            .WithName("UpdateItem")
            .WithSummary("Atualiza um item existente")
            .WithDescription("Atualiza os dados do item com o identificador informado.")
            .Accepts<UpdateItensRequest>("application/json")
            .Produces<ItensResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);

        group.MapDelete("/{id:guid}", DeleteAsync)
            .WithName("DeleteItem")
            .WithSummary("Remove um item")
            .WithDescription("Remove o item com o identificador informado.")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);

        return app;
    }

    private static async Task<Ok<List<ItensResponse>>> GetAllAsync(
        IItemService service,
        CancellationToken cancellationToken)
    {
        var items = await service.GetAllAsync(cancellationToken);
        return TypedResults.Ok(items.Select(Map).ToList());
    }

    private static async Task<Results<Ok<ItensResponse>, NotFound>> GetByIdAsync(
        Guid id,
        IItemService service,
        CancellationToken cancellationToken)
    {
        var item = await service.GetByIdAsync(id, cancellationToken);
        return item is null ? TypedResults.NotFound() : TypedResults.Ok(Map(item));
    }

    private static async Task<Created<ItensResponse>> CreateAsync(
        CreateItensRequest request,
        IItemService service,
        CancellationToken cancellationToken)
    {
        var item = await service.CreateAsync(
            new CreateItemCommand(request.ShoppingListId, request.Name, request.Quantity, request.Unit),
            cancellationToken);

        return TypedResults.Created($"/itens/{item.Id}", Map(item));
    }

    private static async Task<Ok<ItensResponse>> UpdateAsync(
        Guid id,
        UpdateItensRequest request,
        IItemService service,
        CancellationToken cancellationToken)
    {
        var item = await service.UpdateAsync(
            id,
            new UpdateItemCommand(request.Name, request.Quantity, request.Unit, request.IsChecked),
            cancellationToken);

        return TypedResults.Ok(Map(item));
    }

    private static async Task<NoContent> DeleteAsync(
        Guid id,
        IItemService service,
        CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id, cancellationToken);
        return TypedResults.NoContent();
    }

    private static ItensResponse Map(ItemDto item) => new(
        item.Id,
        item.ShoppingListId,
        item.Name,
        item.Quantity,
        item.Unit,
        item.IsChecked,
        item.CreatedAt,
        item.UpdatedAt);
}