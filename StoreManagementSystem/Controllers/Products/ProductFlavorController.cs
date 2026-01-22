using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DTOs.Products.ProductFlavor;
using StoreManagementSystem.Services;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductFlavorController : ControllerBase
    {
        private readonly IProductFlavorService _productFlavorService;

        public ProductFlavorController(IProductFlavorService productFlavorService)
        {
            _productFlavorService = productFlavorService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productFlavorService.GetListAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductFlavorCreateDto dto)
        {
            ResultService result = await _productFlavorService.CreateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductFlavorUpdateDto dto)
        {
            ResultService result = await _productFlavorService.UpdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResultService result = await _productFlavorService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }
    }
}
