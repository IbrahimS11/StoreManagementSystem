using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DTOs.Products.Category;
using StoreManagementSystem.Services;
using StoreManagementSystem.Services.Interfaces.Products;

namespace StoreManagementSystem.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _categoryService.GetListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            ResultService result = await _categoryService.CreateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }

        
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            ResultService result = await _categoryService.UpdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResultService result = await _categoryService.DeleteAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result.Result());

            return Ok(result.Result());
        }
    }
}
