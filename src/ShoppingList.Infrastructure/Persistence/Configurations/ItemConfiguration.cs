using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Infrastructure.Persistence.Configurations;

public sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(item => item.Id);

        builder.Property(item => item.Name)
            .IsRequired()
            .HasMaxLength(Item.MaxNameLength);

        builder.Property(item => item.Quantity)
            .HasColumnType("decimal(18,2)");

        builder.Property(item => item.Unit)
            .HasMaxLength(Item.MaxUnitLength);

        builder.HasOne(item => item.ShoppingList)
            .WithMany(list => list.Items)
            .HasForeignKey(item => item.ShoppingListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}