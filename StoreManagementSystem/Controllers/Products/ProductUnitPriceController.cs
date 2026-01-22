using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DTOs.Products.ProductUnitPrice;
using StoreManagementSystem.Services.Interfaces.Products;
using StoreManagementSystem.Services;

namespace StoreManagementSystem.Controllers.Products
{
    [ApiController]

    [Route("api/[controller]")]
    public class ProductUnitPriceController : ControllerBase
    {
        private readonly IProductUnitPriceService _productUnitPriceService;

        public ProductUnitPriceController(IProductUnitPriceService productUnitPriceService)
        {
            _productUnitPriceService = productUnitPriceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productUnitPriceService.GetListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductUnitPriceCreateDto dto)
        {
            ResultService result = await _productUnitPriceService.CreateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUnitPriceUpdateDto dto)
        {
            ResultService result = await _productUnitPriceService.UpdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResultService result = await _productUnitPriceService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }
    }
}
