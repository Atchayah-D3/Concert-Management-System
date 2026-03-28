namespace WebApplication1.Models
{
    public enum UserRole
    {
        AUDIENCE, CONCERT_CREATOR,ARTIST,HALL_OWNER
    }
    public class User
    {
        public int UserId { get; set; }
        public string UUID { get; set; }
        public string? UserName { get; set; } = null!;
        public UserRole Role { get; set; } = UserRole.AUDIENCE;
        public string Email { get; set; } = null!;
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Concert>? Concerts { get; set; }
        public ICollection<Hall>? Halls { get; set; }
        public ICollection<HallBooking> HallBookings { get; set; }

    }
}
