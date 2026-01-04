using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreManagementSystem.Data.Config.Customers
{
    public class CustomerAddressConfiguration: IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Details)
                   .HasMaxLength(150);

            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Street)
                   .WithMany()
                   .HasForeignKey(x => x.StreetId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(x => new { x.CityId, x.StreetId });
        }
    }
}
