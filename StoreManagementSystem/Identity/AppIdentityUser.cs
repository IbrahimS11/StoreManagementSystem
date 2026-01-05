using Microsoft.AspNetCore.Identity;

namespace StoreManagementSystem.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
