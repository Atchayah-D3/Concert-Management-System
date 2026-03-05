namespace WebApplication1.DTO.Response
{
    public class LoginResDto
    {
        public int UserId { get; set; }
        public bool Success { get; set; } 
        public required string Token { get; set; } = string.Empty;
        public string LoginMessage { get; set; } = string.Empty;
    }
}
