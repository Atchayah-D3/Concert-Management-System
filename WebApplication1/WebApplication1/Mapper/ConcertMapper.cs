using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class ConcertMapper
    {
        public static Concert ToEntity(ConcertReqDto request)
        {
            return new Concert
            {
                ConcertName = request.ConcertName,
                ConcertSpecs = ConcertSpecMapper.ToEntity(request.ConcertSpec),
            };
        }
        public static ConcertResDto ToResponse(Concert concert)
        {
            return new ConcertResDto
            {
                ConcertId = concert.ConcertId,
                ConcertName = concert.ConcertName,
                ConcertSpec = ConcertSpecMapper.ToResponse(concert.ConcertSpecs),
                CreatorId=concert.CreatorId

            };
        }
        public static IEnumerable<ConcertResDto> ToResponse(IEnumerable<Concert> concerts)
        {
            return concerts.Select(ConcertMapper.ToResponse).ToList();             
        }
    }
}
