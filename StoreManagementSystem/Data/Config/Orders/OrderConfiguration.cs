using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Date)
                   .IsRequired();

            builder.Property(o => o.TotalAmount)
                   .HasPrecision(12, 2)
                   .IsRequired();


            builder.Property(o => o.Note)
                   .HasMaxLength(150)
                   .IsRequired(false);

            builder.Property(o => o.Status)
                   .HasDefaultValue(OrderStatus.Pending);

            builder.HasOne(o => o.Customer)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.InitailPayment)
                   .WithOne(cp => cp.Order)
                   .HasForeignKey<Order>(cp => cp.InitialPaymentId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
