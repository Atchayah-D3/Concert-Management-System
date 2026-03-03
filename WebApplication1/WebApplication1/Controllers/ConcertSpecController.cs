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
    [Route("[controller]/")]
    public class ConcertSpecController : ControllerBase
    {
        private  IConcertSpecService _concertSpecService;
        public ConcertSpecController(IConcertSpecService concertSpecService)
        {
            _concertSpecService = concertSpecService;
        }
        [HttpPost]
        public ActionResult<ConcertSpecResDto> Create(ConcertSpecReqDto request)
        {
            if (ModelState.IsValid)
            {
                ConcertSpec concertSpec = ConcertSpecMapper.ToEntity(request);
                ConcertSpecResDto response=ConcertSpecMapper
                    .ToResponse(_concertSpecService.Create(concertSpec));
                return CreatedAtAction(nameof(Get),
                    new
                    {
                        id = response.ConcertId
                    },
                    response
                    );
            }
            return BadRequest(ModelState);

        }
        [HttpGet("{concertSpecId}")]
        public ActionResult<ConcertSpecResDto> Get(int concertSpecId)
        {
            ConcertSpec concertSpec = _concertSpecService.Get(concertSpecId);
            if (concertSpec == null)
                return NotFound(new
                {
                    id=concertSpecId,
                    message=$" No concert spec found with ConcertSpec Id {concertSpecId}"
                });
            return Ok(new
            {
                id=concertSpecId,
                message="Concert fetched successfully",
                data=concertSpec
            });
        }
        [HttpPut("{concertSpecId}")]
        public ActionResult Update(int concertSpecId,ConcertSpecReqDto request)
        {
            ConcertSpec concertSpec = ConcertSpecMapper.ToEntity(request);
            if (_concertSpecService.Update(concertSpecId, concertSpec))
            {
                return NoContent();
            }
            return NotFound(new
            {
                id=concertSpecId,
                message=$"No concertSpec found with the concert spec id {concertSpecId}"
            });
        }
        
        [HttpDelete("{concertSpecId}")]
        public ActionResult Delete(int concertSpecId) {
            if (_concertSpecService.Delete(concertSpecId)) 
            return Ok(
                new
                {
                    message="The Concert Spec was deleted successfully"
                });
            return NotFound(
                new
                {
                    message="The Concert Spec was not found"
                });
        }

    }
}
