using StoreManagementSystem.Identity;

namespace StoreManagementSystem.Services.Interfaces.Account
{
    public interface ITokenService
    {
        public Task<string> Generate(AppIdentityUser userFromDb);
        public Task<string> Refresh(string token);
    }
}
