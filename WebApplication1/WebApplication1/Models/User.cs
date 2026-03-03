namespace WebApplication1.Models
{
    public enum UserRole
    {
        AUDIENCE, CONCERT_CREATOR,ARTIST
    }
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; } = null!;
        public UserRole Role { get; set; } = UserRole.AUDIENCE;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public ICollection<Booking>? Bookings { get; set; }

    }
}
