using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.RepositoryImpl
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly AppDbContext _dbContext;
        public ConcertRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Concert Add(Concert concert)
        {
            _dbContext.Concerts.Add(concert);
            _dbContext.SaveChanges();
            return concert;
        }

        public bool Delete(int concertId)
        {
          Concert conert= GetById(concertId);
            _dbContext.Concerts.Remove(conert);
             _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Concert> GetAll()
        {
            return _dbContext.Concerts
                .Include(c=>c.ConcertSpecs)
                .ToList();
        }

        public Concert GetById(int concertId)
        {
            Concert? concert = _dbContext.Concerts
                .Include(c=>c.ConcertSpecs)
                .FirstOrDefault(c=>c.ConcertId==concertId);
            return concert;
        }

        public void Update()
        {
          _dbContext.SaveChanges();
        }
    }
}