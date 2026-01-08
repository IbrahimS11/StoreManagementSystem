using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DTOs.Products.Product;
using StoreManagementSystem.Repositories.Implementations.Products;
using StoreManagementSystem.Services;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductReadDto> productReadDtos = await productService.GetAllAsync();

            return Ok(productReadDtos.ToList());
        }
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            ProductDetailsDto? productDetailsDto = await productService.GetDetailsAsync(id);
            if(productDetailsDto is null)
            {
                return NotFound(new { id });
            }
            return Ok(productDetailsDto);
        }

        [HttpGet("GetRange")]
        public async Task<IActionResult> GetRangeAsync(int page=1)
        {
            IEnumerable<ProductReadDto> productReadDtos = await productService.GetRangeAsync(page);
            return Ok(productReadDtos);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto model)
        {
            ResultService result=await productService.CreateAsync(model);
            if (result.IsSuccess)
            {
                return Ok(new {  result.IsSuccess, id=result.Data });
            }
            return BadRequest(new {  result.IsSuccess, errors = result.Errors } );
        }

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
