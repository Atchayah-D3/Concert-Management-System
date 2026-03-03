using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IConcertSpecService
    {
        ConcertSpec Create(ConcertSpec concertSpec);
        bool Update(int concertSpecId, ConcertSpec UpdateConcertSpec);
        ConcertSpec Get(int concertSpecId);
        bool Delete(int concertSpecId);
    }
}
