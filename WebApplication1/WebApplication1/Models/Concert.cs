namespace WebApplication1.Models
{
    public class Concert
    {
        public int ConcertId { get; set; }
        public required string ConcertName { get; set; }
        public ConcertSpec ConcertSpecs { get; set; } = null!; 
        public ICollection<Booking>? Bookings { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; } = null!;
        public string? CustomHall { get; set; }
        public ICollection<HallBooking> HallBookings { get; set; } = null!;

    }
}