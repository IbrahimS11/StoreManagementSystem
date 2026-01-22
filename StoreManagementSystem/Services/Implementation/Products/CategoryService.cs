
using StoreManagementSystem.DTOs.Products.Category;
using StoreManagementSystem.Repositories.Implementations.UnitOfWork;
using StoreManagementSystem.Repositories.Interfaces;
using StoreManagementSystem.Repositories.Interfaces.Products;
using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Services.Implementation.Products
{
    public class CategoryService :   ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(IUnitOfWork unitOfWork , ICategoryRepository categoryRepo)
        {
            _unitOfWork = unitOfWork;
            _categoryRepo = categoryRepo;
        }

        public async Task<ResultService> CreateAsync(CategoryCreateDto dto)
        {
            Category category = new()
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl
            };

            _categoryRepo.Add(category);

            int countChange = await _unitOfWork.SaveChangesAsync();

            if (countChange > 0)
                return ResultService.Success(new { Id = category.Id });

            return ResultService.Failure("category", "Category was not added");
        }

        public async Task<ResultService> UpdateAsync(CategoryUpdateDto dto)
        {
            Category category = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl
            };

            _categoryRepo.Update(category);

            int countChange = await _unitOfWork.SaveChangesAsync();

            if (countChange > 0)
                return ResultService.Success(new { Id = category.Id });

            return ResultService.Failure("updateCategory", "Error occurred while updating");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            Category? category = await _categoryRepo.FindAsync(id);

            if (category == null)
                return ResultService.Failure("categoryId", "Not found");

            _categoryRepo.Delete(category);

            int countChange = await _unitOfWork.SaveChangesAsync();

            if (countChange > 0)
                return ResultService.Success(new { Id = category.Id });

            return ResultService.Failure("category", "Some products are using this category");
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _categoryRepo.GetAllAsync();

            return categories.Select(x => new CategoryReadDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            });
        }
        public async Task<IEnumerable<CategoryListDto>> GetListAsync()
        {
            IEnumerable<Category> categories = await _categoryRepo.GetAllAsync();

            return categories.Select(x => new CategoryListDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }

    }
}
