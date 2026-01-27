using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.DTOs.Account;
using StoreManagementSystem.Identity;
using StoreManagementSystem.Services;
using StoreManagementSystem.Services.Interfaces.Account;


namespace StoreManagementSystem.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly IAuthService authService;

        public AccountController(UserManager<AppIdentityUser> userManager , IAuthService authService)
        {
            this.userManager = userManager;
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await authService.LoginAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(new { result.IsSuccess, token = result.Data });
                }
                else
                {
                    return BadRequest(result.Result());
                }
            }
            return BadRequest(ModelState);

        }

        [HttpPost("register")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> RegisterByAdmin(RegisterByAdminDto model)
        {
           ResultService result= await authService.RegisterAsync(model);
            if (result.IsSuccess)
              {
                return Ok(result.Result());
              }
              else
              {
                return BadRequest(result.Result());
            }


        }

        

    }
}
