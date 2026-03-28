using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IHallService
    {
        Task<Hall> AddHall(Hall request);
        List<Hall> GetAll();
        Hall GetHall(int id);
        Hall UpdateHall(int hallId,Hall updatedHall);
    }
}
