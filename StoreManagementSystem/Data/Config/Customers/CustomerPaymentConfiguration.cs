using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Customers
{
    public class CustomerPaymentConfiguration : IEntityTypeConfiguration<CustomerPayment>
    {
        public void Configure(EntityTypeBuilder<CustomerPayment> builder)
        {

            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Amount)
                   .HasPrecision(10,2)
                   .IsRequired();

            builder.Property(cp => cp.BalanceAfter)
                   .HasPrecision(10,2)
                   .IsRequired();

            builder.Property(cp => cp.Date)
                   .IsRequired();

            builder.Property(cp => cp.Note)
                   .HasMaxLength(150)
                   .IsRequired(false);



        }
    }
}
