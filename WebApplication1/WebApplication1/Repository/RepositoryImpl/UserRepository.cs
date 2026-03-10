using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.RepositoryImpl
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Add(User user)
        {
            
               await _dbContext.Users.AddAsync(user);
               await _dbContext.SaveChangesAsync();
                 return user;
        }

        public bool Delete(int userId)
        {
            User deleteUser = Get(userId);
            if ( deleteUser== null)
                return false;
            _dbContext.Users.Remove(deleteUser);
            return true;
        }

        public User Get(int userId)
        {
            return _dbContext.Users.Find(userId);
        }
        public User GetByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u=>u.Email==email);
        }
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList<User>();
        }

        public void Update(int userId, User user)
        {
            _dbContext.SaveChanges();
        }

        public int GetUserId(string uuid)
        {
            return _dbContext.Users
                .Where(u => u.UUID == uuid)
                .Select(u => u.UserId)
                .FirstOrDefault();
        }
    }
}
