using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.RepositoryImpl
{
    public class HallRepository : IHallRepository
    {
        private readonly AppDbContext _dbContext;
        public HallRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Hall Create(Hall request)
        {
            _dbContext.Halls.Add(request);
            Console.Write(_dbContext.SaveChanges());
            return request;
        }

        public List<Hall> GetAll()
        {
            return _dbContext.Halls
                .Include(h => h.Bookings)
                .Include(h=>h.HallOwner)
                .ToList();
        }
        public Hall Get(int id)
        {
            return _dbContext.Halls
                .Include(h=>h.Bookings)
                .Include(h=>h.HallOwner)
                .FirstOrDefault(h => h.HallId == id);
        }
        public Hall Update(Hall old,Hall updated)
        {
            _dbContext.SaveChanges();
            return updated;
        }
    }
}
