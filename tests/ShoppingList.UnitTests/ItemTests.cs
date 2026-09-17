using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Exceptions;

namespace ShoppingList.UnitTests;

public sealed class ItemTests
{
    [Fact]
    public void Constructor_ShouldCreateItemWithDefaults()
    {
        var item = new Item(Guid.NewGuid(), "Leite", 2, "L");

        Assert.NotEqual(Guid.Empty, item.Id);
        Assert.NotEqual(Guid.Empty, item.ShoppingListId);
        Assert.Equal("Leite", item.Name);
        Assert.Equal(2m, item.Quantity);
        Assert.Equal("L", item.Unit);
        Assert.False(item.IsChecked);
        Assert.NotEqual(default, item.CreatedAt);
        Assert.Null(item.UpdatedAt);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_ShouldThrowWhenNameIsInvalid(string? name)
    {
        Assert.Throws<DomainException>(() => new Item(Guid.NewGuid(), name!, 1));
    }

    [Fact]
    public void Constructor_ShouldThrowWhenNameExceedsMaxLength()
    {
        var name = new string('a', Item.MaxNameLength + 1);

        Assert.Throws<DomainException>(() => new Item(Guid.NewGuid(), name, 1));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_ShouldThrowWhenQuantityIsNotPositive(decimal quantity)
    {
        Assert.Throws<DomainException>(() => new Item(Guid.NewGuid(), "Arroz", quantity));
    }

    [Fact]
    public void Rename_ShouldUpdateNameAndUpdatedAt()
    {
        var item = new Item(Guid.NewGuid(), "Leite", 1);

        item.Rename("Leite Integral");

        Assert.Equal("Leite Integral", item.Name);
        Assert.NotNull(item.UpdatedAt);
    }

    [Fact]
    public void Rename_ShouldThrowWhenNameIsEmpty()
    {
        var item = new Item(Guid.NewGuid(), "Leite", 1);

        Assert.Throws<DomainException>(() => item.Rename("  "));
        Assert.Equal("Leite", item.Name);
    }

    [Fact]
    public void Check_ShouldMarkAsChecked()
    {
        var item = new Item(Guid.NewGuid(), "Leite", 1);

        item.Check();

        Assert.True(item.IsChecked);
        Assert.NotNull(item.UpdatedAt);
    }

    [Fact]
    public void Uncheck_ShouldMarkAsUnchecked()
    {
        var item = new Item(Guid.NewGuid(), "Leite", 1);
        item.Check();

        item.Uncheck();

        Assert.False(item.IsChecked);
    }

    [Fact]
    public void SetUnit_ShouldTrimAndIgnoreEmptyValues()
    {
        var item = new Item(Guid.NewGuid(), "Leite", 1, " Litro ");

        item.SetUnit("   ");

        Assert.Null(item.Unit);
    }
}