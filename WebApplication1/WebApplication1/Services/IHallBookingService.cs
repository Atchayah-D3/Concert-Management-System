using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IHallBookingService
    {
        Task<HallBooking> ProcessBooking(int hallId,HallBooking request);
        List<HallBooking> GetHallBookings(int hallId);
        bool ProcessCancel(int bookingId);
    }
}
