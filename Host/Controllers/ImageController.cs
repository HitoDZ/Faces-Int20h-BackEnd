using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class ImageController : ControllerBase
    {
        [HttpGet(RouteConstants.Images)]
        public IActionResult GetAll()
        {
            return Ok("hahahaha");
        }

    }
}