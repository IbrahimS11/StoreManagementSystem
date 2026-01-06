using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces.Products;
namespace StoreManagementSystem.Repositories.Implementations.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Product>> GetRangeAsync(int skip, int take)
        {
            return await context.Products.OrderBy(x=>x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }


    }
}



