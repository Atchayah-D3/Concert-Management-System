namespace WebApplication1.Models
{
    public enum BookingStatus
    {
        WAITING,CONFIRMED,UNCONFIRMED
    }
    public class Booking
    {
        public int BookingId { get; set; }
        public int ConcertId { get; set; }
        public int UserId { get; set; }
        public Concert Concert { get; set; } = null!;
        public User Audience { get; set; } = null!;

        public BookingStatus Status { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
