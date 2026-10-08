using Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<object> _passwordHasher = new();

        public string Hash(string password)
        {
            return this._passwordHasher.HashPassword(null!, password);
        }

        public bool Verify(string password, string passwordHash)
        {
            var result = this._passwordHasher.VerifyHashedPassword(null!, passwordHash, password);

            return result == PasswordVerificationResult.Success;
        }
    }
}
