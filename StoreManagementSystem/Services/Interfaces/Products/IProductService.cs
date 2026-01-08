using Microsoft.Extensions.Logging;
using StoreManagementSystem.DTOs.Products.Product;

namespace StoreManagementSystem.Services.Interfaces.Products
{
    public interface IProductService
    {
        public Task<ResultService> CreateAsync(ProductCreateDto productDTO);
        public Task<ResultService> UpdateAsync(ProductUpdateDto productDTO);

        public Task<ProductDetailsDto?> GetDetailsAsync(int id);
        public Task<IEnumerable<ProductReadDto>> GetRangeAsync(int page);
        public Task<ResultService> DeleteByIdAsync(int id);
        public Task<IEnumerable<ProductReadDto>> GetAllAsync();

    }
}
