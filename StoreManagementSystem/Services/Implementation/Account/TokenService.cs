using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StoreManagementSystem.Identity;
using StoreManagementSystem.Services.Interfaces.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreManagementSystem.Services.Implementation.Account
{
    
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly IConfiguration config;

        public TokenService(UserManager<AppIdentityUser> _userManager , IConfiguration config) 
        {
            userManager = _userManager;
            this.config = config;
        }

        public async Task<string> Generate(AppIdentityUser userFromDb)
        {
            List<Claim> claimsUser = new() {
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.MobilePhone,userFromDb.PhoneNumber!),
                        new Claim(ClaimTypes.NameIdentifier,userFromDb.Id)

                    };

            var roles = await userManager.GetRolesAsync(userFromDb);
            foreach (var role in roles)
            {
                claimsUser.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claimsUser,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
              

        }

        public async Task<string> Refresh(string token)
        {
            //refresh token logic to be implemented
            return token;
        }
    }
}
