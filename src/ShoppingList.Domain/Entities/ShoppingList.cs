using ShoppingList.Domain.Exceptions;

namespace ShoppingList.Domain.Entities;

public sealed class ShoppingList
{
    public const int MaxNameLength = 100;

    private readonly List<Item> _items = [];

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

    private ShoppingList()
    {
    }

    public ShoppingList(string name)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;

        AssignName(name);
    }

    public void Rename(string name)
    {
        AssignName(name);
        Touch();
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
        Touch();
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        Touch();
    }

    private void AssignName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("O nome da lista de compras é obrigatório.");
        }

        name = name.Trim();

        if (name.Length > MaxNameLength)
        {
            throw new DomainException($"O nome da lista de compras deve ter no máximo {MaxNameLength} caracteres.");
        }

        Name = name;
    }

    private void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}