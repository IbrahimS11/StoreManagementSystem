using Microsoft.EntityFrameworkCore;

namespace StoreManagementSystem.Data
{
    public class AppDbContext: DbContext
    {
        //Customers
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerPayment> CustomerPayments { get; set; }

        //Inventories
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        //Locations
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }

        //Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //Products
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFlavor> ProductFlavors { get; set; }
        public DbSet<ProductUnitPrice> ProductUnitPrices { get; set; }

        //Suppliers
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierAddress> SupplierAddresses { get; set; }
        public DbSet<SupplierPayment> SupplierPayments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(builder);
        }

    }
}
