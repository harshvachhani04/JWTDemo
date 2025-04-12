using JWTDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtTokenGenerator tokenGenerator;

        public LoginController(JwtTokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LoginDTO loginDTO)
        {
            if(loginDTO.Username == "admin" && loginDTO.Password == "admin")
            {
                var token = this.tokenGenerator.GenerateToken();
                return Ok(new { token = token });
            }
            return Unauthorized("Invalid Credentials");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("True");
        }
    }
}
