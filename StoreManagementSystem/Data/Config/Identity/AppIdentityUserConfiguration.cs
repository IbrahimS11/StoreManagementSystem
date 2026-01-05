using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Identity;

namespace StoreManagementSystem.Data.Config.Identity
{
    public class AppIdentityUserConfiguration : IEntityTypeConfiguration<AppIdentityUser>
    {
        public void Configure(EntityTypeBuilder<AppIdentityUser> builder)
        {
            builder.HasOne(u => u.Customer)
                   .WithOne(c => c.AppIdentityUser)
                   .HasForeignKey<AppIdentityUser>(u => u.CustomerId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.Supplier)
                   .WithOne(s => s.AppIdentityUser)
                   .HasForeignKey<AppIdentityUser>(u => u.SupplierId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
