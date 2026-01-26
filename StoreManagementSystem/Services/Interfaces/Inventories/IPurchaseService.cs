using StoreManagementSystem.DTOs.Inventories.Purchase;

namespace StoreManagementSystem.Services.Interfaces.Inventories
{
    public interface IPurchaseService
    {
        public  Task<ResultService> CreateByAdminAsync(PurchaseCreateDto model);
        public  Task<ResultService> CompletePurchaseAsync(PurchaseCompleteDto purchaseCompleteDto);
    }
}
