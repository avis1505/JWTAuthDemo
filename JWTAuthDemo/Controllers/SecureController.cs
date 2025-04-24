using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {

        [Authorize]
        [HttpGet("User")]
        public IActionResult UserAccess() => Ok("Hello,Authenticated User");

        [Authorize(Roles = "Admin")]
        [HttpGet("Admin")]
        public IActionResult AdminAccess() => Ok("Hello,Admin");
    }
}
