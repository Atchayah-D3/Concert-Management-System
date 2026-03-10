using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<User> Create(User user);
        User Get(int userId);
        IEnumerable<User> GetAll();
        bool Update(int userId, User user);
        string HashPassword(User user);
        bool Delete(int userId);
        Task<int> GetUserId(string uuid);
    }
}
