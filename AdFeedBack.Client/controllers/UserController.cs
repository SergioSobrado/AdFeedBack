using AdFeedBack.Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdFeedBack.Client.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AdFeedBackApiServices _adFeedBackApiServices;

        public UserController(AdFeedBackApiServices adFeedBackApiServices)
        {
            _adFeedBackApiServices = adFeedBackApiServices;
        }
        // GET: api/<GetString>
        [HttpGet("GetLoggedUser")]
        public async Task<IActionResult> GetLoggedUser()
        {
            return await _adFeedBackApiServices.GetAsync($"/api/User/GetLoggedUser");
        }
    }
}
