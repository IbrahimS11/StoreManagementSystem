
namespace StoreManagementSystem.Repositories.Interfaces.Suppliers
{
    public interface ISupplierPaymentRepository : ICrudRepository<SupplierPayment,Guid>
    {
        public Task<SupplierPayment?> GetLastPaymentAsync(Guid SupplierId);
    }
}
