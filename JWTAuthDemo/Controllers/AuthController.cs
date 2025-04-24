using JWTAuthDemo.Model;
using JWTAuthDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService jwtService;

        private static List<User> users = new ();

        public AuthController(JwtService _jwtService)
        {
            jwtService = _jwtService;
        }


        [HttpPost("Register")]
        public IActionResult Register([FromBody] User user)
        {
            if (users.Any(u => u.Username == user.Username))
                return BadRequest("User Already Exists");

            users.Add(user);
            return Ok("User Register succesfully");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User login)
        {
            var user = users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if(user == null)
                return Unauthorized("Invalid Credentials");

            var token = jwtService.GenerateJwtToken(user);
            return Ok(token);
        }

    }
}
