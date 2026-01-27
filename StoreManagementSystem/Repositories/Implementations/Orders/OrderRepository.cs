
using StoreManagementSystem.Repositories.Interfaces.Orders;

namespace StoreManagementSystem.Repositories.Implementations.Orders
{
    public class OrderRepository : CrudRepository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
