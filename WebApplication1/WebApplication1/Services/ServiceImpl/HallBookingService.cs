using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services.ServiceImpl
{
    public class HallBookingService :IHallBookingService
    {
        private readonly IHallBookingRepository _hallBookingRepo;
        private readonly IHallRepository _hallRepository;
        public HallBookingService(IHallBookingRepository hallBookingRepo,
            IHallRepository hallRepository)
        {
            _hallBookingRepo = hallBookingRepo;
            _hallRepository = hallRepository;
        }

        public List<HallBooking> GetHallBookings(int hallId)
        {
            return _hallBookingRepo.GetHallBookings(hallId);
        }

        public async Task<HallBooking> ProcessBooking(int hallId,HallBooking request)
        {
            if (request==null) { return null; }
           
            Hall requestedHall = _hallRepository.Get(hallId);

            if (requestedHall == null) { Console.WriteLine($"Hall with{hallId} not exist"); return null; }
            List<HallBooking> hallBookings =requestedHall.Bookings;
            bool isHallAvailable = true;
            DateTime requestFrom = request.FromDateTime;
            DateTime requestTo = request.ToDateTime;
            if (hallBookings.Count>0){                
                foreach (HallBooking booking in hallBookings)
                {
                    DateTime bookingFrom = booking.FromDateTime;
                    DateTime bookingTo = booking.ToDateTime;
                    if ((requestTo <= bookingFrom) || (requestFrom >= bookingTo))
                        continue;
                    
                    isHallAvailable = false;
                }
            }            
            if (!isHallAvailable)
                return null;
            request.HallId = hallId;
            request.Status = BookingStatus.CONFIRMED;
            double totalHrs = (requestTo - requestFrom).TotalHours;
            request.Price = requestedHall.PricePerHour*totalHrs;
            return _hallBookingRepo.Add(request); ;
        }
        public bool ProcessCancel(int bookingId)
        {
            HallBooking hallBooking = _hallBookingRepo.GetBooking(bookingId);
            if (hallBooking == null)
                return false;
            return _hallBookingRepo.DeleteBooking(hallBooking);
        }
    }
}
