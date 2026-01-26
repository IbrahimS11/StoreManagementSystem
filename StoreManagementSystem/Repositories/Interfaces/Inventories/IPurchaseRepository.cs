using StoreManagementSystem.DTOs.Inventories.Purchase;

namespace StoreManagementSystem.Repositories.Interfaces.Inventories
{
    public interface IPurchaseRepository :ICrudRepository<Purchase,Guid>
    {
        public Task<IEnumerable<PurchaseListDto>> GetPurchaseListAsync(Guid SupplierId, int skip, int take);
        public Task<PurchaseReadDto?> GetPurchasesDetailsAsync(Guid Id);
    }
}
