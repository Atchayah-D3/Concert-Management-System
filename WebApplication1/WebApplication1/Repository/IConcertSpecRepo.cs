using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IConcertSpecRepo
    {
        ConcertSpec Add(ConcertSpec concertSpec);
        void Update();
        ConcertSpec Get(int concertSpecId);
        bool Delete(int concertSpecId);
    }
}
