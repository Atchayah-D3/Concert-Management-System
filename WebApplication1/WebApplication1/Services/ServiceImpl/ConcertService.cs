using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class ConcertService: IConcertService
    {
        private readonly IConcertRepository _concertRepo;
        private readonly IConcertSpecService _concertSpecService;
        public ConcertService(IConcertRepository concertRepository,
            IConcertSpecService concertSpecService)
        {
            _concertRepo = concertRepository;
            _concertSpecService = concertSpecService;
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
        public IEnumerable<Concert> FetchUserConcert(int userId)
        {
            return _concertRepo.GetByUserId(userId);
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
                _concertSpecService.Update(concert.ConcertSpecs.ConcertSpecId, updatedConcertSpec);
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
