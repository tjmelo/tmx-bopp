namespace ShoppingList.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string resource, object id)
        : base($"O recurso '{resource}' com id '{id}' não foi encontrado.")
    {
        Resource = resource;
        Id = id;
    }

    public string Resource { get; }
    public object Id { get; }
}