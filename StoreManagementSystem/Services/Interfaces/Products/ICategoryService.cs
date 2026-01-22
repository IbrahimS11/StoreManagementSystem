
using StoreManagementSystem.DTOs.Products.Category;

namespace StoreManagementSystem.Services.Interfaces.Products
{
    public interface ICategoryService 
    {
        Task<ResultService> CreateAsync(CategoryCreateDto dto);
        Task<ResultService> UpdateAsync(CategoryUpdateDto dto);
        Task<ResultService> DeleteAsync(int id);
        Task<IEnumerable<CategoryReadDto>> GetAllAsync();
        Task<IEnumerable<CategoryListDto>> GetListAsync();

    }
}
