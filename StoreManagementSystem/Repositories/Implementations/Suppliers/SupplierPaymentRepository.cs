using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces.Suppliers;

namespace StoreManagementSystem.Repositories.Implementations.Suppliers
{
    public class SupplierPaymentRepository: CrudRepository<SupplierPayment,Guid>,ISupplierPaymentRepository
    {
        private readonly AppDbContext context;

        public SupplierPaymentRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<SupplierPayment?> GetLastPaymentAsync(Guid SupplierId)
        {
           return await context.SupplierPayments.OrderByDescending(sp => sp.Date).FirstOrDefaultAsync();
        }
    }
}
