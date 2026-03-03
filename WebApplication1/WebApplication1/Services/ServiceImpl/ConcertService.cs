using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class ConcertService: IConcertService
    {
        private readonly IConcertRepository _concertRepo;
        public ConcertService(IConcertRepository concertRepository)
        {
            _concertRepo = concertRepository;
        }
        public  Concert AddConcert(Concert concert)
        {

            _concertRepo.Add(concert);
            return concert;
        }
        public  Concert GetConcert(int id)
        {
            return _concertRepo.GetById(id);

        }
        public IEnumerable<Concert> GetAllConcert()
        {
            return _concertRepo.GetAll();
        }
        public bool UpdateConcert(int id, Concert updatedConcert)
        {
            Concert concert = GetConcert(id);
            ConcertSpec updatedConcertSpec = updatedConcert.ConcertSpecs;
            if (concert == null)
                return false;
            concert.ConcertName = updatedConcert.ConcertName ?? concert.ConcertName;
            if ( updatedConcertSpec!= null)
            {
                ConcertSpec oldConcertSpec = concert.ConcertSpecs;
                oldConcertSpec.Artist = updatedConcertSpec.Artist ?? oldConcertSpec.Artist;
                oldConcertSpec.Venue = updatedConcertSpec.Venue ?? oldConcertSpec.Venue;
                oldConcertSpec.Price = updatedConcertSpec.Price ?? oldConcertSpec.Price;
                oldConcertSpec.Date_Time = updatedConcertSpec.Date_Time ?? oldConcertSpec.Date_Time;
            }
            _concertRepo.Update();
            return true;
        }
        public bool DeleteConcert(int concertId)
        {
            if (!isConcertExists(concertId))
                return false;
            return _concertRepo.Delete(concertId);
        }
        public bool isConcertExists(int id)
        {
            return _concertRepo.GetById(id)!=null;
        }
    }
}
