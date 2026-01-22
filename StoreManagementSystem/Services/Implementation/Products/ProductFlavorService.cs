using StoreManagementSystem.DTOs.Products.ProductFlavor;
using StoreManagementSystem.Repositories.Implementations.UnitOfWork;
using StoreManagementSystem.Repositories.Interfaces;
using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Services.Implementation.Products
{
    public class ProductFlavorService : IProductFlavorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICrudRepository<ProductFlavor, int> _productFlavorRepo;

        public ProductFlavorService(
            IUnitOfWork unitOfWork,
            ICrudRepository<ProductFlavor, int> productFlavorRepo)
        {
            _unitOfWork = unitOfWork;
            _productFlavorRepo = productFlavorRepo;
        }

        public async Task<ResultService> CreateAsync(ProductFlavorCreateDto flavorDto)
        {
            ProductFlavor newFlavor = new()
            {
                Name = flavorDto.Name
            };

            _productFlavorRepo.Add(newFlavor);

            int countChange = await _unitOfWork.SaveChangesAsync();

            if (countChange > 0)
                return ResultService.Success(new { Id = newFlavor.Id });

            return ResultService.Failure("productFlavor", "The flavor was not added");
        }

        public async Task<ResultService> UpdateAsync(ProductFlavorUpdateDto flavorDto)
        {
            ProductFlavor flavor = new()
            {
                Id = flavorDto.Id,
                Name = flavorDto.Name
            };

            var existingFlavor = await _productFlavorRepo.FindAsync(flavorDto.Id);
            if (existingFlavor == null)
                return ResultService.Failure("productFlavorId", "Not found");


            _productFlavorRepo.Update(flavor);

            int countChange = await _unitOfWork.SaveChangesAsync();

            if (countChange > 0)
                return ResultService.Success(new { Id = flavor.Id });

            return ResultService.Failure("updateProductFlavor", "Error occurred while updating");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            ProductFlavor? flavor = await _productFlavorRepo.FindAsync(id);

            if (flavor == null)
                return ResultService.Failure("productFlavorId", "Not found");

            _productFlavorRepo.Delete(flavor);

            int countChange = await _unitOfWork.SaveChangesAsync();

            if (countChange > 0)
                return ResultService.Success(new { Id = flavor.Id });

            return ResultService.Failure("productFlavor", "Some products are using this flavor");
        }

        public async Task<IEnumerable<ProductFlavorReadDto>> GetListAsync()
        {
            IEnumerable<ProductFlavor> flavors = await _productFlavorRepo.GetAllAsync();

            return flavors.Select(x => new ProductFlavorReadDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
