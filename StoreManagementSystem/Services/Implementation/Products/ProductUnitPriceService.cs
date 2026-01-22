using StoreManagementSystem.DTOs.Products.ProductUnitPrice;
using StoreManagementSystem.Repositories.Implementations.UnitOfWork;
using StoreManagementSystem.Repositories.Interfaces;
using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Services.Implementation.Products
{
    public class ProductUnitPriceService :  IProductUnitPriceService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ICrudRepository<ProductUnitPrice, int> _unitPriceRepo;

        public ProductUnitPriceService(IUnitOfWork unitofwork, ICrudRepository<ProductUnitPrice, int> unitPriceRepo)
        {
            _unitofwork = unitofwork;
            _unitPriceRepo = unitPriceRepo;
        }

        public async Task<ResultService> CreateAsync(ProductUnitPriceCreateDto unitPriceDto)
        {
            ProductUnitPrice newUnitPrice = new()
            {
                UnitPrice = unitPriceDto.UnitPrice
            };
            _unitPriceRepo.Add(newUnitPrice);

            int countChange =await _unitofwork.SaveChangesAsync();

            if (countChange > 0) return ResultService.Success(new { Id = newUnitPrice.Id });

            else return ResultService.Failure("newUnitPrice", "the unit price is not add");
            
        }

        public async Task<ResultService> UpdateAsync(ProductUnitPriceUpdateDto unitPriceDto)
        {
            ProductUnitPrice newUnitPrice = new()
            {
                UnitPrice = unitPriceDto.UnitPrice
            };

            var existingUnitPrice = await _unitPriceRepo.FindAsync(unitPriceDto.Id);
            if (existingUnitPrice == null)
                return ResultService.Failure("unitPriceId", "Not found");


            _unitPriceRepo.Update(newUnitPrice);

            int countChange = await _unitofwork.SaveChangesAsync();

            if (countChange > 0) return ResultService.Success(new { Id = newUnitPrice.Id });

            else return ResultService.Failure("updateUnitPrice", "Error occurce at update");

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            ProductUnitPrice? unitPrice =await _unitPriceRepo.FindAsync(id);
            if (unitPrice == null) return ResultService.Failure("unitPriceId", "Not found");
            _unitPriceRepo.Delete(unitPrice);

            int countChange = await _unitofwork.SaveChangesAsync();


            if (countChange > 0) return ResultService.Success(new { Id = unitPrice.Id });

            else return ResultService.Failure("unitPrice", "Some product contain this unit price");

        }

        public async Task<IEnumerable<ProductUnitPriceReadDto>> GetListAsync()
        {
            IEnumerable<ProductUnitPrice> unitPriceDto = await _unitPriceRepo.GetAllAsync();
            return unitPriceDto.Select(x=>new ProductUnitPriceReadDto()
            {
                Id = x.Id,
                UnitPrice=x.UnitPrice
            });
        }

    }
}
