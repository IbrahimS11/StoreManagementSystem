using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces.Inventories;

namespace StoreManagementSystem.Repositories.Implementations.Inventories
{
    public class InventoryRepository : CrudRepository<Inventory, Guid>, IInventoryRepository
    {
        AppDbContext context;
        public InventoryRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<List<Inventory>?> AddPurchaseItemsToInventoryAsync(Guid PurchaseId)
        {
            Purchase? purchase= await context.Purchases.Include(p=>p.PurchaseItems).FirstOrDefaultAsync(p => p.Id == PurchaseId);
            if (purchase == null) return null;

            List<Inventory> inventories = purchase.PurchaseItems.Select(pi => new Inventory()
            {
                Id = Guid.NewGuid(),
                ProductId = pi.ProductId,
                Quantity=pi.Quantity,
                PurchaseItemId=pi.Id

            }).ToList();

            return inventories;

                throw new NotImplementedException();
        }
    }
}
