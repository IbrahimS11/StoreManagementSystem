using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ProductFlavor)
                   .WithMany(f=>f.Products)
                   .HasForeignKey(p => p.ProductFlavorId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ProductUnitPrice)
                   .WithMany(up => up.Products)
                   .HasForeignKey(p => p.ProductUnitPriceId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Inventories)
                   .WithOne(i => i.Product)
                   .HasForeignKey(i => i.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.OrderItems)
                   .WithOne(oi => oi.Product)
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
