namespace StoreManagementSystem.Repositories.Interfaces.Inventories
{
    public interface IInventoryRepository : ICrudRepository<Inventory,Guid>
    {
        public Task<List<Inventory>?> AddPurchaseItemsToInventoryAsync(Guid PurchaseId);

    }
}
