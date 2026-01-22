using AutoMapper;
using StoreManagementSystem.AutoMapper.Products;
using StoreManagementSystem.DTOs.Products.Product;

using StoreManagementSystem.Repositories.Interfaces;
using StoreManagementSystem.Repositories.Interfaces.Products;
using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Services.Implementation.Products
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;
        private readonly IProductRepository productRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly ICrudRepository<ProductUnitPrice, int> productUnitPriceRepo;
        private readonly ICrudRepository<ProductFlavor,int> productFlavorRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        


        public ProductService(ILogger<ProductService> _logger, 
            IProductRepository _productRepo,
            ICategoryRepository _categoryRepo,
            ICrudRepository<ProductUnitPrice,int> _productUnitPriceRepo,
            ICrudRepository<ProductFlavor, int> _productFlavorRepo,
            IUnitOfWork _unitOfWork,
            IMapper _mapper


            )
        {
            this.logger = _logger;
            this.productRepo = _productRepo;
            this.categoryRepo= _categoryRepo;
            this.productFlavorRepo = _productFlavorRepo;
            this.productUnitPriceRepo = _productUnitPriceRepo;
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }
        public async Task<ResultService> CreateAsync(ProductCreateDto productDTO)
        {
            bool ProductExists = await productRepo.IsExistAsync(productDTO.CategoryId, productDTO.ProductUnitPriceId, productDTO.ProductFlavorId,null);
            if (ProductExists)
            {
                return ResultService.Failure("ProductExists","this product is already exist");
            }
            

            var category =await  categoryRepo.GetByIdAsync(productDTO.CategoryId);
            var unitPrice = await productUnitPriceRepo.GetByIdAsync(productDTO.ProductUnitPriceId);
            var flavor = await productFlavorRepo.GetByIdAsync(productDTO.ProductFlavorId);

          
            ResultService result = new();
            if (category == null)  result.AddError("CategoryId","Not Found");
            if (unitPrice == null)   result.AddError("productUnitPriceId","Not Found");
            if (flavor == null)  result.AddError("ProductFlavorId", "Not Found");

           

            if (result.Errors.Count > 0) { result.IsSuccess = false; return result; }

            Product newProduct = mapper.Map<Product>(productDTO);

             productRepo.Add(newProduct);

            int count= await unitOfWork.SaveChangesAsync();
            if(count>0)
            {
                return ResultService.Success(newProduct.Id);
            }

            logger.LogError("Failed to create this product : {@Product}",newProduct);

            return ResultService.Failure("","Failed to create product");
            
            
        }

        public async Task<ResultService> UpdateAsync(ProductUpdateDto productDTO)
        {
            Product? productFromDb = await productRepo.GetByIdAsync(productDTO.Id);
            if (productFromDb is null) return ResultService.Failure("productId", "Not Found");

            bool ProductExists = await productRepo.IsExistAsync(productDTO.CategoryId, productDTO.ProductUnitPriceId, productDTO.ProductFlavorId,productDTO.Id);
            if (ProductExists)
            {
                return ResultService.Failure("ProductExists", "this product is already exist");
            }


            var category = await categoryRepo.GetByIdAsync(productDTO.CategoryId);
            var unitPrice = await productUnitPriceRepo.GetByIdAsync(productDTO.ProductUnitPriceId);
            var flavor = await productFlavorRepo.GetByIdAsync(productDTO.ProductFlavorId);


            ResultService result = new();
            if (category == null) result.AddError("CategoryId", "Not Found");
            if (unitPrice == null) result.AddError("productUnitPriceId", "Not Found");
            if (flavor == null) result.AddError("ProductFlavorId", "Not Found");



            if (result.Errors.Count > 0) { result.IsSuccess = false; return result; }

            productFromDb = mapper.Map<Product>(productDTO);

            productRepo.Update(productFromDb);

            int count = await unitOfWork.SaveChangesAsync();
            if (count > 0)
            {
                return ResultService.Success(productFromDb.Id);
            }

            logger.LogError("Failed to Update this product : {productFromDb}", productFromDb);

            return ResultService.Failure("", "Failed to Update product");


        }


        public async Task<ProductDetailsDto?> GetDetailsAsync(int id)
        {
            Product? productFromDb = await productRepo.GetDetails(id);
            if(productFromDb is null) return null;

            ProductDetailsDto productDetails = mapper.Map<ProductDetailsDto>(productFromDb);

            return productDetails;
        }


        public async Task<IEnumerable<ProductReadDto>> GetRangeAsync(int page)
        {
            if(page < 1) page = 1;
            int take = 10;
            int skip = (page - 1) * take;
            var productsFromDb = await productRepo.GetRangeAsync(skip,take);
            List<ProductReadDto> productReadDtos = mapper.Map<List<ProductReadDto>>(productsFromDb);

            return productReadDtos;
        }
        public async Task<ResultService> DeleteByIdAsync(int id)
        {
            var product = await productRepo.GetByIdAsync(id);
            if(product == null)
            {
                return ResultService.Failure("ProductId","Not Found");
            }

            productRepo.Delete(product);
            int count = await unitOfWork.SaveChangesAsync();
            if(count>0)
            {
                return ResultService.Success(id);
            }

            logger.LogError("Failed to delete this product : {product}", product);
            return ResultService.Failure("ProductId",$"Failed to delete product With Id {id}");
        }



        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var productReadDtos = await productRepo.GetAllIncludeCategoryUnitPriceFavor();
            return  productReadDtos;
        }

       

        
    }
}
