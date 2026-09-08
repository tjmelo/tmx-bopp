using ShoppingList.Application.Exceptions;
using ShoppingList.Application.Items;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Repositories;

namespace ShoppingList.UnitTests;

public sealed class ItemServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldAddItemAndReturnDto()
    {
        var repository = new FakeItemRepository();
        var service = new ItemService(repository);

        var result = await service.CreateAsync(new CreateItemCommand("Café", 1, "kg"));

        Assert.Equal("Café", result.Name);
        Assert.Equal(1m, result.Quantity);
        Assert.Equal("kg", result.Unit);
        Assert.False(result.IsChecked);
        Assert.Single(repository.Items);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllItems()
    {
        var repository = new FakeItemRepository
        {
            Items =
            {
                new Item("Açúcar", 1),
                new Item("Sal", 2),
            },
        };
        var service = new ItemService(repository);

        var result = await service.GetAllAsync();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNullWhenItemDoesNotExist()
    {
        var service = new ItemService(new FakeItemRepository());

        var result = await service.GetByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnItemWhenItExists()
    {
        var item = new Item("Pão", 3);
        var service = new ItemService(new FakeItemRepository { Items = { item } });

        var result = await service.GetByIdAsync(item.Id);

        Assert.NotNull(result);
        Assert.Equal(item.Name, result.Name);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowWhenItemDoesNotExist()
    {
        var service = new ItemService(new FakeItemRepository());

        var command = new UpdateItemCommand("Pão", 3, null, false);

        await Assert.ThrowsAsync<NotFoundException>(
            () => service.UpdateAsync(Guid.NewGuid(), command));
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateItemFields()
    {
        var item = new Item("Pão", 3);
        var repository = new FakeItemRepository { Items = { item } };
        var service = new ItemService(repository);

        var result = await service.UpdateAsync(
            item.Id,
            new UpdateItemCommand("Pão Francês", 4, "un", true));

        Assert.Equal("Pão Francês", result.Name);
        Assert.Equal(4m, result.Quantity);
        Assert.Equal("un", result.Unit);
        Assert.True(result.IsChecked);
        Assert.Equal("Pão Francês", item.Name);
        Assert.True(item.IsChecked);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowWhenItemDoesNotExist()
    {
        var service = new ItemService(new FakeItemRepository());

        await Assert.ThrowsAsync<NotFoundException>(
            () => service.DeleteAsync(Guid.NewGuid()));
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveItem()
    {
        var item = new Item("Queijo", 1);
        var repository = new FakeItemRepository { Items = { item } };
        var service = new ItemService(repository);

        await service.DeleteAsync(item.Id);

        Assert.Empty(repository.Items);
    }

    private sealed class FakeItemRepository : IItemRepository
    {
        public List<Item> Items { get; set; } = [];

        public Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => Task.FromResult(Items.FirstOrDefault(item => item.Id == id));

        public Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<IReadOnlyList<Item>>(Items.ToList());

        public Task AddAsync(Item item, CancellationToken cancellationToken = default)
        {
            Items.Add(item);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Item item, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Item item, CancellationToken cancellationToken = default)
        {
            Items.Remove(item);
            return Task.CompletedTask;
        }
    }
}