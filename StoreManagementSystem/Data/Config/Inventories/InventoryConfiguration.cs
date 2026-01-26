using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Models.Inventories
{ 
public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Quantity)
               .IsRequired();


        builder.HasOne(i => i.PurchaseItem)
               .WithOne(pi => pi.Inventory)
               .HasForeignKey<Inventory>(i => i.PurchaseItemId)
               .OnDelete(DeleteBehavior.NoAction); 

        builder.HasOne(i => i.Product)
               .WithMany(p => p.Inventories)
               .HasForeignKey(i => i.ProductId)
               .OnDelete(DeleteBehavior.NoAction); 
    }
}
}
