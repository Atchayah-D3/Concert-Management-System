using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IHallBookingRepository
    {
        HallBooking Add(HallBooking request);
        List<HallBooking> GetHallBookings(int hallId);

        HallBooking GetBooking(int bookingId);
        bool DeleteBooking(HallBooking hallBooking);
    }
}
