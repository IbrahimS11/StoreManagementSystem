using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces.Products;
namespace StoreManagementSystem.Repositories.Implementations.Products
{
    public class ProductRepository : CrudRepository<Product, int>, IProductRepository
    {
        private readonly DbSet<Product> dbSet;
        public ProductRepository(AppDbContext _context):base(_context)
        {
            this.dbSet = _context.Set<Product>();
        }
        
        public async Task<bool> IsExistAsync(int CategoryId,int ProductUnitPriceId,int ProductFlavorId , int ? ProductId)
        {
            return await dbSet.AnyAsync(p => p.CategoryId == CategoryId && p.ProductUnitPriceId == ProductUnitPriceId && p.ProductFlavorId == ProductFlavorId && p.Id !=ProductId);
        }

        public async Task<Product?> GetDetails(int id)
        {
            return await dbSet.Where(p => p.Id == id).Include(p=>p.Category).Include(p=>p.ProductUnitPrice).Include(p=>p.ProductFlavor).FirstOrDefaultAsync();
        }
       
    }
}



