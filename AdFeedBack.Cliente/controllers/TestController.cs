using AdFeedBack.Client.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdFeedBack.Client.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AdFeedBackApiServices _adFeedBackApiServices;
        
        public TestController(AdFeedBackApiServices adFeedBackApiServices)
        {
            _adFeedBackApiServices = adFeedBackApiServices;
        }
        // GET: api/<GetString>
        [HttpGet("GetStrings")]
        public async Task<IActionResult> GetStrings()
        {
            return await _adFeedBackApiServices.GetAsync($"/api/Test/GetStrings");
        }
    }
}
