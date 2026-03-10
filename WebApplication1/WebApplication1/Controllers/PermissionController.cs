using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]/")]
    [Produces("application/json")]
    public class PermissionController : ControllerBase
    {
        private readonly OpaService _opaService;
      public  PermissionController(OpaService opaService)
        {
            _opaService = opaService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Permission>>> GetPermissions(string role)
        {
            var permissions= await _opaService.GetPermissions(role);
            PermissionMapper.ToDto(permissions);
            return Ok(permissions);
        }
    }
}
