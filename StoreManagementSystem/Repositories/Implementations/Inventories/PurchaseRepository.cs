using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.DTOs.Inventories.Purchase;
using StoreManagementSystem.DTOs.Inventories.PurchaseItem;
using StoreManagementSystem.Repositories.Interfaces.Inventories;

namespace StoreManagementSystem.Repositories.Implementations.Inventories
{
    public class PurchaseRepository : CrudRepository<Purchase, Guid> , IPurchaseRepository
    {
        private readonly AppDbContext context;

        public PurchaseRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<IEnumerable<PurchaseListDto>> GetPurchaseListAsync(Guid SupplierId,int skip,int take)
        {
            return await context.Purchases.Where(p => p.SupplierId == SupplierId)
                                          .OrderByDescending(p => p.Date)
                                          .Skip(skip)
                                          .Take(take)
                                          .Select(p => new PurchaseListDto
                                          {
                                              Id = p.Id,
                                              Date = p.Date,
                                              TotalAmount = p.TotalAmount
                                          })
                                          .AsNoTracking()
                                          .ToListAsync();
        }

        public async Task<PurchaseReadDto?> GetPurchasesDetailsAsync(Guid Id)
        {
            return await context.Purchases.Where(p=>p.Id==Id)
                .Select(p=> new PurchaseReadDto
                {
                Id = p.Id,
                Date = p.Date,
                TotalAmount = p.TotalAmount,
                Note = p.Note,
                PurchaseItems = new List<PurchaseItemReadDto>(p.PurchaseItems.Select(pi=> new PurchaseItemReadDto
                {
                    Id=pi.Id,
                    Quantity=pi.Quantity,
                    UnitPrice=pi.UnitPrice,
                    ProductId=pi.ProductId
                })),
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == Id);
        }
        
    }
}
