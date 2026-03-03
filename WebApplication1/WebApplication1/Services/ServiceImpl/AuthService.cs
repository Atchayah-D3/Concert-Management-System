using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthService(IUserRepository userRepository,IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }
        public User Login (User request)
        {
            var user = _userRepository.GetByEmail(request.Email);
            if (user == null)
                return null;
            var result = _passwordHasher.VerifyHashedPassword(
        user,
        user.HashedPassword,
        request.HashedPassword
    );

            if (result == PasswordVerificationResult.Failed)
                return null;
            return user;
        }
    }
}
