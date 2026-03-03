using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IBookingRepository
    {
        Booking BookConcert(Booking booking);
        IEnumerable<BookingResDto> Get(int userId);
    }
}
