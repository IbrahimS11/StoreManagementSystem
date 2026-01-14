using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.DTOs.Account;
using StoreManagementSystem.Identity;
using StoreManagementSystem.Services.Interfaces.Account;
using System.Security.Cryptography;
using System.Text;
namespace StoreManagementSystem.Services.Implementation.Account
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly ITokenService tokenService;
        private readonly ILogger<AuthService> logger;

        public AuthService(UserManager<AppIdentityUser> _userManager , ITokenService tokenService, ILogger<AuthService> _logger )
        {
            userManager = _userManager;
            this.tokenService = tokenService;
            logger = _logger;
        }
        public async Task<ResultService> LoginAsync(LoginDto model)
        {
            AppIdentityUser? userFromDb = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.Phone);

            if (userFromDb == null)return ResultService.Failure("notfound", "خطا في رقم الهاتف او الباسورد");

            
            bool checkPassword = await userManager.CheckPasswordAsync(userFromDb, model.Password);
            if (checkPassword==false) return ResultService.Failure("notfound", "خطا في رقم الهاتف او الباسورد");


            string token = await tokenService.Generate(userFromDb);

            ResultService resultService = ResultService.Success(token);

            logger.LogInformation( "User with phone {Phone} logged in at {Time}", userFromDb.PhoneNumber,  DateTime.UtcNow);

            return resultService;

                
               
        }

        public async Task<ResultService> RegisterAsync(RegisterByAdminDto model)
        {

            var exists = await userManager.Users.AnyAsync(x => x.PhoneNumber == model.Phone);

            if (exists) return ResultService.Failure("PhoneExists", "رقم الهاتف مسجل بالفعل");

            AppIdentityUser user;

            
            if (model.role == "supplier")
            {
                 user = new()
                {
                    UserName = model.Name,
                    PhoneNumber = model.Phone,
                    Supplier = new()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Phone = model.Phone,
                        Address = new SupplierAddress()
                        {
                            Id = Guid.NewGuid(),
                            CityId = model.CityId,
                            StreetId = model.StreetId,
                            Details = model.AddressDetails

                        }

                    } 

                };
            }
            else 
            {
                user = new()
                {
                    UserName = model.Name,
                    PhoneNumber = model.Phone,
                    Customer = new()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Phone = model.Phone,
                        Address = new CustomerAddress()
                        {
                            Id = Guid.NewGuid(),
                            CityId = model.CityId,
                            StreetId = model.StreetId,
                            Details = model.AddressDetails

                        }

                    }
                };
            }

            

            var password = GenerateSecureRandomString(12);

            
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                if (model.role == "supplier") await userManager.AddToRoleAsync(user, "supplier");
                else await userManager.AddToRoleAsync(user, "customer");

                return ResultService.Success(new { user.PhoneNumber, password });
            }
            else
            {
                ResultService resultService = new();
                resultService.IsSuccess = false;
                foreach (var error in result.Errors)
                {
                    resultService.AddError(error.Code, error.Description);
                }
                return resultService;
            }
        }

        private static string GenerateSecureRandomString(int length = 32)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789";
            var data = new byte[length];
            RandomNumberGenerator.Fill(data);

            var result = new StringBuilder(length);
            foreach (var b in data)
                result.Append(chars[b % chars.Length]);

            return result.ToString();
        }

    }


}
