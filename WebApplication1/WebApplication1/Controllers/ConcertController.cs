using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Security.Claims;
using WebApplication1.Services.ServiceImpl;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[Controller]/")]
    [Produces("application/json")]    
    public class ConcertController : ControllerBase
    {
        private readonly IConcertService _concertService;
        private readonly OpaService _opaService;
        private readonly IUserService _userService;
        public ConcertController(IConcertService concertService,
            OpaService opaService,
            IUserService userService)
        {
            _concertService = concertService;
            _opaService = opaService;
            _userService = userService;
        }
       // [Authorize(Roles ="CONCERT_CREATOR")]
        [Authorize]
        [HttpPost]
        //public ActionResult<ConcertResDto> Create(ConcertReqDto concertDto)
        public async Task<ActionResult<ConcertResDto>> Create(ConcertReqDto concertDto)
        {
            // int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            //  string uuid=User.FindFirst(ClaimTypes.)
            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           // string UUID = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            int userId = await _userService.GetUserId(UUID);
           var role = User.FindFirst(ClaimTypes.Role)?.Value;
            bool allowed = role != null ?
                await _opaService.IsAllowed(userId, role, "create_concert", "concert") : false;
           // Console.WriteLine($"User Id: {userId}");
            if (!allowed)
                return Forbid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Concert concert = ConcertMapper.ToEntity(concertDto);
            concert.CreatorId = userId;
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
        [Authorize]
        [HttpPut("{id:min(1)}")]
        public async Task<ActionResult<ConcertResDto>> Update([FromRoute] int id,[FromBody]ConcertReqDto request)
        {
            //int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(UUID);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            Concert concert = _concertService.GetConcert(id);
            if (concert == null)
                return NotFound(new
                {
                    concertId = id,
                    message = "Requested Concert to update was not exists"
                });

            bool allowed = role != null ?
                await _opaService.IsAllowed(userId, role, "update_concert", "concert", new { owner = concert.CreatorId })
                : false;
            if (!allowed)
                return Forbid();

            Concert update = ConcertMapper.ToEntity(request);
            _concertService.UpdateConcert(id, update);
            return NoContent();
            
            
            
        }
        [Authorize]
        [HttpDelete("{id:min(1)}")]
        public async Task<ActionResult> Delete(int id)
        {
            // int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(UUID);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            Concert concert = _concertService.GetConcert(id);
            if(concert==null)
                return NotFound(new
                {
                    concertId = id,
                    message = "Requested Concert to delete was not exists"
                });

            bool allowed = role != null ? 
                await _opaService.IsAllowed(userId, role, "delete_concert", "concert",new {owner=concert.CreatorId}) 
                : false;            
            if (!allowed)
                return Forbid();

            _concertService.DeleteConcert(id);
            return  Ok(new
                {
                    concertId = id,
                    message = "Concert removed successfully"
                });
                
        }
    }
}