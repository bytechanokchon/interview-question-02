using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Persistences
{
    public interface IAppDbContext
    {
        Task<int> SaveChangeAsync();

        public DbSet<User> Users { get; }
    }
}
