using Microsoft.AspNetCore.Mvc;

namespace Examples.Before.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TraderController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
