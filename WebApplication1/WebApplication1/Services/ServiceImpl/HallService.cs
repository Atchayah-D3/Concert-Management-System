using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _hallRepository;
        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public async Task<Hall> AddHall(Hall request)
        {
            return _hallRepository.Create(request);
        }

        public List<Hall> GetAll()
        {
            return _hallRepository.GetAll();
        }

       public Hall GetHall(int id)
        {
            return _hallRepository.Get(id);
        }
        public Hall UpdateHall(int hallId,Hall updated)
        {
            Hall existing = GetHall(hallId);
            existing.HallName = updated.HallName;
            existing.capacity = updated.capacity;
            existing.Location = updated.Location;
            existing.PricePerHour = updated.PricePerHour;
            return _hallRepository.Update(existing, updated);
        }

    }
}
