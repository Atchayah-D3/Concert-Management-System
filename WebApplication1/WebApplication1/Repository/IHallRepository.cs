using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IHallRepository
    {
        Hall Create(Hall request);
        List<Hall> GetAll();
        Hall Get(int id);
        Hall Update(Hall old,Hall updated);
    }
}
