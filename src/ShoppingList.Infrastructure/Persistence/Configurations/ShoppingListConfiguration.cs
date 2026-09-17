using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingListEntity = ShoppingList.Domain.Entities.ShoppingList;

namespace ShoppingList.Infrastructure.Persistence.Configurations;

public sealed class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingListEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingListEntity> builder)
    {
        builder.ToTable("ShoppingLists");

        builder.HasKey(list => list.Id);

        builder.Property(list => list.Name)
            .IsRequired()
            .HasMaxLength(ShoppingListEntity.MaxNameLength);
    }
}