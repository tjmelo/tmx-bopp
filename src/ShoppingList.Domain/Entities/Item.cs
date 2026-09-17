using ShoppingList.Domain.Exceptions;

namespace ShoppingList.Domain.Entities;

public sealed class Item
{
    public const int MaxNameLength = 100;
    public const int MaxUnitLength = 50;

    public Guid Id { get; private set; }
    public Guid ShoppingListId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Quantity { get; private set; }
    public string? Unit { get; private set; }
    public bool IsChecked { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public ShoppingList? ShoppingList { get; private set; }

    private Item()
    {
    }

    public Item(Guid shoppingListId, string name, decimal quantity, string? unit = null)
    {
        Id = Guid.NewGuid();
        ShoppingListId = shoppingListId;
        CreatedAt = DateTime.UtcNow;

        AssignName(name);
        AssignQuantity(quantity);
        AssignUnit(unit);
    }

    public void Rename(string name)
    {
        AssignName(name);
        Touch();
    }

    public void SetQuantity(decimal quantity)
    {
        AssignQuantity(quantity);
        Touch();
    }

    public void SetUnit(string? unit)
    {
        AssignUnit(unit);
        Touch();
    }

    public void Check()
    {
        IsChecked = true;
        Touch();
    }

    public void Uncheck()
    {
        IsChecked = false;
        Touch();
    }

    private void AssignName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("O nome do item é obrigatório.");
        }

        name = name.Trim();

        if (name.Length > MaxNameLength)
        {
            throw new DomainException($"O nome do item deve ter no máximo {MaxNameLength} caracteres.");
        }

        Name = name;
    }

    private void AssignQuantity(decimal quantity)
    {
        if (quantity <= 0)
        {
            throw new DomainException("A quantidade do item deve ser maior que zero.");
        }

        Quantity = quantity;
    }

    private void AssignUnit(string? unit)
    {
        if (!string.IsNullOrWhiteSpace(unit) && unit.Trim().Length > MaxUnitLength)
        {
            throw new DomainException($"A unidade do item deve ter no máximo {MaxUnitLength} caracteres.");
        }

        Unit = string.IsNullOrWhiteSpace(unit) ? null : unit.Trim();
    }

    private void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}