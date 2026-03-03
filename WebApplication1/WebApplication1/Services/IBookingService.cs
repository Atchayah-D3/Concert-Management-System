using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBookingService
    {
        Booking BookConcert(Booking booking);
        IEnumerable<BookingResDto> Get(int userId);
    }
}
