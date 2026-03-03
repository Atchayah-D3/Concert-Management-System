using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string email, UserRole role);
    }
}
