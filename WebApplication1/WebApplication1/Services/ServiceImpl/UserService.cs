using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public string HashPassword(User user)
        {
            return "";
           // return _passwordHasher.HashPassword(user, user.HashedPassword);
        }
        public async Task<User> Create(User user)
        {

          //  user.HashedPassword = HashPassword(user);
            await _userRepository.Add(user);
            return user;
        }

        public bool Delete(int userId)
        {
            return _userRepository.Delete(userId);
        }

        public User Get(int userId)
        {
            return _userRepository.Get(userId);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public bool Update(int userId, User updateUser)
        {
            User user = Get(userId);
            if (user == null)
                return false;
            user.UserName = updateUser.UserName ?? user.UserName;
          //  if (updateUser.HashedPassword != null)
            //    user.HashedPassword = _passwordHasher.HashPassword(user, updateUser.HashedPassword);
            return true;
        }
        public async Task<int> GetUserId(string uuid)
        {
            return _userRepository.GetUserId(uuid);
        }
    }
}
