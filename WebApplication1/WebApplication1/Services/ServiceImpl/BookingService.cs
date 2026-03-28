using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class BookingService : IBookingService
    {
        private string BOOKING_NOT_FOUND = "Booking not found with given Booking Id";
        private string PAST_BOOKING_CANCELLATION = "Can't cancel bookings of past concerts";
        private string CANCELLATION_SUCCESS = "Booking cancelled successfully";
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
        public string CancelBooking(int bookingID)
        {
            Booking booking = _bookingRepository.GetBooking(bookingID);
            if (booking == null)
               return BOOKING_NOT_FOUND ;
            if (booking.Concert.ConcertSpecs.Date_Time <= DateTime.UtcNow)
                return PAST_BOOKING_CANCELLATION;
            booking.Status = BookingStatus.CANCELLED;
            _bookingRepository.Update();
            return CANCELLATION_SUCCESS;
        }
    }
}
