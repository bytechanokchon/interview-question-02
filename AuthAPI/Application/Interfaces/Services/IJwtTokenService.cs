namespace Application.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(int userId, string username);
    }
}
