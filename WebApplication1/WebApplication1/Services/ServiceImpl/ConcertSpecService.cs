using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class ConcertSpecService : IConcertSpecService
    {
        private IConcertSpecRepo _concertSpecRepo;
        public ConcertSpecService(IConcertSpecRepo concertSpecRepo)
        {
            _concertSpecRepo = concertSpecRepo;
        }
        public ConcertSpec Create(ConcertSpec concertSpec)
        {
            return _concertSpecRepo.Add(concertSpec);
        }

        public bool Delete(int concertSpecId)
        {
            return _concertSpecRepo.Delete(concertSpecId);
        }

        public ConcertSpec Get(int concertSpecId)
        {
            return _concertSpecRepo.Get(concertSpecId);
        }      

        public bool Update(int concertSpecId,ConcertSpec updateConcertSpec)
        {
            ConcertSpec concertSpec = Get(concertSpecId);
            if (concertSpec == null)
                return false;
            concertSpec.Artist = updateConcertSpec.Artist ?? concertSpec.Artist;
            concertSpec.Venue = updateConcertSpec.Venue ?? concertSpec.Venue;
            concertSpec.Price = updateConcertSpec.Price ?? concertSpec.Price;
            concertSpec.Date_Time = updateConcertSpec.Date_Time ?? concertSpec.Date_Time;
            return true;
        }
    }
}
