
using StoreManagementSystem.DTOs.Products.ProductFlavor;

namespace StoreManagementSystem.Services.Interfaces.Products
{
    public interface IProductFlavorService 
    {
        public Task<ResultService> CreateAsync(ProductFlavorCreateDto flavorDto);

        public Task<ResultService> UpdateAsync(ProductFlavorUpdateDto flavorDto);

        public Task<ResultService> DeleteAsync(int id);

        public Task<IEnumerable<ProductFlavorReadDto>> GetListAsync();
    }
}
