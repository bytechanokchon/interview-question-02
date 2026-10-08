using Application.DTOs.Services.Users;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> IsExistsAsync(string username);
        Task CreateAsync(string username, string password);
        Task<UserInfoDto?> GetUserInfoByUsernameAsync(string username);
    }
}
