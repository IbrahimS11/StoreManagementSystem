using StoreManagementSystem.DTOs.Products.ProductUnitPrice;
using StoreManagementSystem.Repositories.Interfaces;

namespace StoreManagementSystem.Services.Interfaces.Products
{
    public interface IProductUnitPriceService
    {
        public Task<ResultService> CreateAsync(ProductUnitPriceCreateDto unitPriceDto);

        public Task<ResultService> UpdateAsync(ProductUnitPriceUpdateDto unitPriceDto);

        public Task<ResultService> DeleteAsync(int id);

        public Task<IEnumerable<ProductUnitPriceReadDto>> GetListAsync();
    }
}
