using StoreManagementSystem.Repositories.Interfaces.Products;

namespace StoreManagementSystem.Repositories.Implementations.Products
{
    public class CategoryRepository : CrudRepository<Category,int>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext _context):base(_context)
        {
        }
        
    }
}
