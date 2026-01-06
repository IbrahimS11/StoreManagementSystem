using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces.Products;

namespace StoreManagementSystem.Repositories.Implementations.Products
{
    public class ProductFlavorRepository : IProductFlavorRepository
    {
        private readonly AppDbContext context;

        public ProductFlavorRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<ProductFlavor>> GetRangeAsync(int skip, int take)
        {
            return await context.ProductFlavors.OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public async Task AddAsync(ProductFlavor productFlavor)
        {
            await context.ProductFlavors.AddAsync(productFlavor);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await context.ProductFlavors.Where(p => p.Id == id).ExecuteDeleteAsync();
        }

        public Task<ProductFlavor?> GetByIdAsync(int id)
        {
            return context.ProductFlavors.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
