using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IAuthService
    {
        User Login(User user);
        User Register(User user);
    }
}
