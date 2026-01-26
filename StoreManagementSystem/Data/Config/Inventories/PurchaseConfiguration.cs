using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Inventories
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
           
            builder.Property(p => p.TotalAmount)
                   .HasPrecision(12, 2)
                   .IsRequired();

            builder.Property(p => p.Status)
                    .HasDefaultValue(PurchaseStatus.Pending);

            builder.Property(p => p.Note)
                   .HasMaxLength(150)
                   .IsRequired(false);

            builder.HasOne(p => p.Supplier)
                   .WithMany(s => s.Purchases)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.InitialPayment)
                   .WithOne(sp => sp.Purchase)
                   .HasForeignKey<Purchase>(p=>p.InitialPaymentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.PurchaseItems)
                   .WithOne(pi => pi.Purchase)
                   .HasForeignKey(pi => pi.PurchaseId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
