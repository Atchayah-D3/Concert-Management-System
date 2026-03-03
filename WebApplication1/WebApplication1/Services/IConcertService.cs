using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IConcertService
    {
        Concert AddConcert(Concert concert);
        Concert GetConcert(int concertId);
        IEnumerable<Concert> GetAllConcert();
        bool UpdateConcert(int concertId, Concert updatedConcert);
        bool DeleteConcert(int concertId);
    }
}
