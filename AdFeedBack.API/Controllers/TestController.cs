using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdFeedBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("GetStrings")]
        public async Task<IActionResult> GetStrings()
        {
            return Ok("Hola Amirekjghrkjegos");
        }
    }
}
