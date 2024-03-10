using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdFeedBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetLoggedUser")]
        public async Task<IActionResult> GetLoggedUser()
        {
            return Ok("Hola Amirekjghrkjegos");
        }
    }
}
