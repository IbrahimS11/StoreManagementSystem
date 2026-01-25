using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DTOs.Products.Product;
using StoreManagementSystem.Repositories.Implementations.Products;
using StoreManagementSystem.Services;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [Authorize(Roles ="admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductReadDto> productReadDtos = await productService.GetAllAsync();

            return Ok(productReadDtos);
        }

        [Authorize(Roles = "customer,admin")]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            ProductDetailsDto? productDetailsDto = await productService.GetDetailsAsync(id);
            if (productDetailsDto is null)
            {
                return NotFound(new { id });
            }
            return Ok(productDetailsDto);
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("GetRange")]
        public async Task<IActionResult> GetRangeAsync(int page = 1)
        {
            IEnumerable<ProductReadDto> productReadDtos = await productService.GetRangeAsync(page);
            return Ok(productReadDtos);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto model)
        {
            ResultService result = await productService.CreateAsync(model);
            if (result.IsSuccess)
            {
                return Ok(new { result.IsSuccess, id = result.Data });
            }
            return BadRequest(new { result.IsSuccess, errors = result.Errors });
        }

        [Authorize(Roles ="admin")]
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto model)
        {
            ResultService result = await productService.UpdateAsync(model);
            if (result.IsSuccess)
            {
                return Ok(new { result.IsSuccess, id = result.Data });
            }
            return BadRequest(new { result.IsSuccess, errors = result.Errors });
        }


        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            ResultService result = await productService.DeleteByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(new { result.IsSuccess, id = result.Data });
            }
            return BadRequest(new { result.IsSuccess, errors = result.Errors });
        }



    }
}
