using StoreManagementSystem.DTOs.Account;

namespace StoreManagementSystem.Services.Interfaces.Account
{
    public interface IAuthService
    {
        public Task<ResultService> LoginAsync(LoginDto model);
        public Task<ResultService> RegisterAsync(RegisterByAdminDto model);
    }
}
