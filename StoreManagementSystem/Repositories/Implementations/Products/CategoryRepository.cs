using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces.Products;

namespace StoreManagementSystem.Repositories.Implementations.Products
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Category>> GetRangeAsync(int skip, int take)
        {
            return await context.Categories.OrderBy(x=>x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public async Task AddAsync(Category category)
        {
            await context.Categories.AddAsync(category);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await context.Categories.Where(p => p.Id == id).ExecuteDeleteAsync();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            return context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
