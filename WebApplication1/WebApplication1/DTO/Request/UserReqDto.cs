using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTO.Request
{
    public class UserReqDto
    {
        public string? UserName { get; set; } = null!;
        [EmailAddress]
        public required string Email { get; set; }
        public string? Password { get; set; } = null!;
        public UserRole Role { get; set; } = UserRole.AUDIENCE;
    }
}
