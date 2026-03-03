using WebApplication1.DTO.Response;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public Booking BookConcert(Booking booking)
        {
            booking.BookingTime = DateTime.UtcNow;
            booking.Status = BookingStatus.CONFIRMED;
            return _bookingRepository.BookConcert(booking);
        }
        public IEnumerable<BookingResDto> Get(int userId)
        {
            return _bookingRepository.Get(userId);
        }
    }
}
