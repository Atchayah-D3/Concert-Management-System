using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.ServiceImpl;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[Controller]/")]
    [Produces("application/json")]    
    public class ConcertController : ControllerBase
    {
        private IConcertService _concertService;
        public ConcertController(IConcertService concertService)
        {
            _concertService = concertService;
        }
        [Authorize(Roles ="CONCERT_CREATOR")]
        [HttpPost]
        public ActionResult<ConcertResDto> Create(ConcertReqDto concertDto)
        {           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Concert concert = ConcertMapper.ToEntity(concertDto);
            Concert savedConcert = _concertService.AddConcert(concert);
            if (savedConcert != null)
            {
                ConcertResDto response = ConcertMapper.ToResponse(savedConcert);
                return CreatedAtAction(nameof(Get),
                new { Id = response.ConcertId },
                response);
            }
            return BadRequest();
            
        }
        [HttpGet("{id:min(1)}")]

        public ActionResult<ConcertResDto> Get(int id)
        {
            
           Concert concert=  _concertService.GetConcert(id);
            if (concert == null)
                return NotFound(new
                {
                    ConcertId = id,
                    message = $"No Concert found with the concert id {id}."
                });
            ConcertResDto response = ConcertMapper.ToResponse(concert);
            return Ok(response);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ConcertResDto>> GetAll()
        {
            IEnumerable<Concert> concerts = _concertService.GetAllConcert();
            IEnumerable<ConcertResDto> response = ConcertMapper.ToResponse(concerts);
            return Ok(response);
        }
        [HttpPut("{id:min(1)}")]
        public ActionResult<ConcertResDto> Update([FromRoute] int id,[FromBody]ConcertReqDto request)
        {
            Concert update = ConcertMapper.ToEntity(request);
            
            if (_concertService.UpdateConcert(id, update))
            {
                return NoContent();
            }
            
            return NotFound(new
                {
                    concertId = id,
                    message = "Requested Concert to update was not exists"
                });
        }

        [HttpDelete("{id:min(1)}")]
        public ActionResult Delete(int id)
        {
            return _concertService.DeleteConcert(id) ? 
                Ok(new {
                    concertId=id,
                    message= "Concert removed successfully" }):
                NotFound(new
                {
                    concertId=id,
                    message= "Requested Concert to delete was not exists"
                });
        }
    }
}