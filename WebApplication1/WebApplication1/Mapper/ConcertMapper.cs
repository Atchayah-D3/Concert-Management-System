using AutoMapper;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class ConcertMapper
    {
        private static  IMapper _mapper;
        public ConcertMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public static Concert ToEntity(ConcertReqDto request)
        {
            return new Concert
            {
                ConcertName = request.ConcertName,
                ConcertSpecs =_mapper.Map<ConcertSpec>(request.ConcertSpec)                
            };
        }
        public static ConcertResDto ToResponse(Concert concert)
        {
            return new ConcertResDto
            {
                ConcertId = concert.ConcertId,
                ConcertName = concert.ConcertName,
                ConcertSpec = _mapper.Map<ConcertSpecDto>(concert.ConcertSpecs),
                CreatorId=concert.CreatorId

            };
        }
        public static IEnumerable<ConcertResDto> ToResponse(IEnumerable<Concert> concerts)
        {
            return concerts.Select(ConcertMapper.ToResponse).ToList();             
        }
    }
}
