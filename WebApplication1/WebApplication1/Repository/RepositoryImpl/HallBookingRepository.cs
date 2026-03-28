using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository.RepositoryImpl
{
    public class HallBookingRepository : IHallBookingRepository
    {
        private readonly AppDbContext _dbContext;
        public HallBookingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public HallBooking Add(HallBooking request)
        {
            _dbContext.HallBookings.Add(request);
            _dbContext.SaveChanges();
            return request;
        }

        public bool DeleteBooking(HallBooking hallBooking)
        {
            HallBooking booking = GetBooking(hallBooking.HallBookingId);
            _dbContext.HallBookings.Remove(booking);
            _dbContext.SaveChanges();
            return true;
        }
        public HallBooking GetBooking(int bookingId)
        {
           HallBooking hallBooking= _dbContext.HallBookings
                .Include(hb=>hb.Hall)
                .Include(hb=>hb.User)
                .FirstOrDefault(hb => hb.HallBookingId == bookingId);
            return hallBooking;
        }
        public List<HallBooking> GetHallBookings(int hallId)
        {
            return _dbContext.HallBookings
                .Where(hb=>hb.HallId==hallId)
                .Include(hb=>hb.Hall)
                .Include(hb=>hb.User)
                .ToList();
        }
    }
}
