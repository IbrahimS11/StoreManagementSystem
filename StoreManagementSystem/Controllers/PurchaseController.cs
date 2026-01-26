using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.DTOs.Inventories.Purchase;
using StoreManagementSystem.Services;
using StoreManagementSystem.Services.Interfaces.Inventories;

namespace StoreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService _purchaseService)
        {
            this.purchaseService = _purchaseService;
        }

         [HttpPost]
         public async Task<IActionResult> CreatePurchaseByAdmin(PurchaseCreateDto model)
         {
           ResultService result= await purchaseService.CreateByAdminAsync(model);
            if (result.IsSuccess)
            {
                return CreatedAtAction("CreatePurchaseByAdmin", result.Result());
            }

            return BadRequest(result.Result());
         }
        [HttpPost("CompletePurchase")]
        public async Task<IActionResult> CompletePurchase(PurchaseCompleteDto model)
        {
            ResultService result = await purchaseService.CompletePurchaseAsync(model);
            if (result.IsSuccess)
            {
                return CreatedAtAction("CompletePurchase", result.Result());
            }

            return BadRequest(result.Result());
        }
    }
}
