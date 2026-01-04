using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Suppliers
{
    public class SupplierAddressConfiguration : IEntityTypeConfiguration<SupplierAddress>
    {
        public void Configure(EntityTypeBuilder<SupplierAddress> builder)
        {
            builder.HasKey(sa => sa.Id);

            builder.HasOne(sa => sa.City)
                   .WithMany()
                   .HasForeignKey(sa => sa.CityId)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(sa => sa.Street)
                   .WithMany()
                   .HasForeignKey(sa => sa.StreetId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
