using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public class UserResDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
       public required string Email { get; set; }
        public UserRole Role { get; set; } = UserRole.AUDIENCE;
    }
}