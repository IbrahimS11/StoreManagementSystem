using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces.Products;

namespace StoreManagementSystem.Repositories.Implementations.Products
{
    public class ProductUnitPriceRepository : IProductUnitPriceRepository
    {
        private readonly AppDbContext context;

        public ProductUnitPriceRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<ProductUnitPrice>> GetRangeAsync(int skip, int take)
        {
            return await context.ProductUnitPrices.OrderBy(x=>x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public async Task AddAsync(ProductUnitPrice unitPrice)
        {
            await context.ProductUnitPrices.AddAsync(unitPrice);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await context.ProductUnitPrices.Where(p => p.Id == id).ExecuteDeleteAsync();
        }

        public Task<ProductUnitPrice?> GetByIdAsync(int id)
        {
            return context.ProductUnitPrices.FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
