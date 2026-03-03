using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.RepositoryImpl
{
    public class ConcertSpecRepo : IConcertSpecRepo
    {
        private readonly AppDbContext _dbContext;
        public ConcertSpecRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ConcertSpec Add(ConcertSpec concertSpec)
        {
            _dbContext.ConcertSpecs.Add(concertSpec);
            _dbContext.SaveChanges();
            return concertSpec;
        }

        public bool Delete(int concertSpecId)
        {
            ConcertSpec concertSpec = Get(concertSpecId);
            if (concertSpec!=null)
            {
                _dbContext.ConcertSpecs.Remove(concertSpec);
                return true;
            }

            return false;
        }

        public ConcertSpec Get(int concertSpecId)
        {
           return _dbContext.ConcertSpecs.Find(concertSpecId);
        }
        public void Update()
        {
            _dbContext.SaveChanges();
        }
    }
}
