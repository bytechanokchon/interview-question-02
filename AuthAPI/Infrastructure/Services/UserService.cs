using Application.Interfaces.Persistences;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _context;

        public UserService(IAppDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> IsExistsAsync(string username)
        {
            return await this._context.Users.Where(x => x.Username == username).AnyAsync();
        }

        public async Task CreateAsync(string username, string password)
        {
            User user = new User();
            user.Username = username;
            user.Password = password;
            user.CreatedAt = DateTime.Now;

            await this._context.Users.AddAsync(user);

            await this._context.SaveChangeAsync();
        }
    }
}
