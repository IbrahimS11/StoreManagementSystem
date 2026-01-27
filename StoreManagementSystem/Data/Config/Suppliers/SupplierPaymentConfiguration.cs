using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Suppliers
{
    public class SupplierPaymentConfiguration : IEntityTypeConfiguration<SupplierPayment>
    {
        public void Configure(EntityTypeBuilder<SupplierPayment> builder)
        {

            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Amount)
                   .HasPrecision(12, 2)
                   .IsRequired();

            builder.Property(cp => cp.BalanceAfter)
                   .HasPrecision(12, 2)
                   .IsRequired();

            builder.Property(cp => cp.Date)
                   .IsRequired();

            builder.Property(cp => cp.Note)
                   .HasMaxLength(150)
                   .IsRequired(false);




        }
    }
}
