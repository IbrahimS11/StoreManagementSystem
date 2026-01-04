using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Customers
{

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Phone)
                   .IsRequired()
                   .HasMaxLength(13);

            builder.HasIndex(c => c.Phone)
                   .IsUnique(true); 

            builder.HasOne(c => c.Address)
                   .WithOne(x=>x.Customer)
                   .HasForeignKey<CustomerAddress>(c => c.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Payments)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
