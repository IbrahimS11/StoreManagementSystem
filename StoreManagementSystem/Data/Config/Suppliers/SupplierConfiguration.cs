using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Customers
{

    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(s => s.Phone)
                   .IsRequired()
                   .HasMaxLength(13);

            builder.HasIndex(s => s.Phone)
                   .IsUnique(true);

            builder.HasOne(s => s.Address)
                   .WithOne(s => s.Supplier)
                   .HasForeignKey<Supplier>(s => s.AddressId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Payments)
                   .WithOne(s => s.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Purchases)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
