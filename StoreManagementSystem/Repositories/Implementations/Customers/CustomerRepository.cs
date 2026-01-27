using StoreManagementSystem.Repositories.Interfaces.Customers;

namespace StoreManagementSystem.Repositories.Implementations.Customers
{
    public class CustomerRepository : CrudRepository<Customer,Guid> , ICustomerRepository
    {
        public CustomerRepository(AppDbContext _context) : base(_context)
        {
        }
       
    }
}
