namespace WebApplication1.DTO.Response
{
    public class ConcertResDto
    {
        public int ConcertId { get; set; }
        public required string ConcertName { get; set; }
        public  ConcertSpecResDto ConcertSpec { get; set; } 

    }
}
