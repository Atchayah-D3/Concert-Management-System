namespace WebApplication1.DTO.Request
{
    public class ConcertReqDto
    {
        public required string ConcertName { get; set; }
        public ConcertSpecReqDto ConcertSpec { get; set; } = null!;
    }
}
