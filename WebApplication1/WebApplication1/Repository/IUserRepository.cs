using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        User Get(int userId);
        User GetByEmail(string email);
        IEnumerable<User> GetAll();
        void Update(int userId, User user);
        bool Delete(int userId);
    }
}
