using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public interface IConcertRepository
    {
        Concert Add(Concert concert);
        Concert GetById(int concertId);
        IEnumerable<Concert> GetAll();
        bool Delete(int concertId);
        void Update();

    }
}
