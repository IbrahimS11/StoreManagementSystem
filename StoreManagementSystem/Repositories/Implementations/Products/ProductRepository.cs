using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.DTOs.Products.Product;
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

        public async Task<List<int>> ProductIdsExist(List<int> ids)
        {
           return await  dbSet.Where(p =>ids.Contains(p.Id) )
                              .Select(p=>p.Id).ToListAsync();

        }

        public async Task<List<ProductListDto>> GetListDtosByIdsAsync(List<int> ids)
        {
            return await dbSet.Where(p => ids.Contains(p.Id))
                              .Select( p => new ProductListDto() {
                                          Id = p.Id,
                                        Price=p.Price }
                                      ).ToListAsync();
        }

        public async Task<List<ProductReadDto>> GetAllIncludeCategoryUnitPriceFavor()
        {
            return await dbSet.Include(p => p.ProductUnitPrice).Include(p => p.ProductFlavor).Include(p => p.Category).Select(p => new ProductReadDto()
            {
                Id = p.Id,
                Price = p.Price,
                CategoryId= p.CategoryId,
                ImageUrl=p.ImageUrl,
                ProductFlavorId=p.ProductFlavorId,
                ProductFlavor=p.ProductFlavor.Name,
                Description=p.Description,
                ProductUnitPrice=p.ProductUnitPrice.UnitPrice,
                CategoryName=p.Category.Name,

            }).ToListAsync();
        }
    }
}



