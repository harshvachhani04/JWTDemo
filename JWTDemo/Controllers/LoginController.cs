using JWTDemo.Data;
using JWTDemo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtTokenGenerator tokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginController(JwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            this.tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            UserDemo user = await _userRepository.GetUserAsync(loginDTO.Username, loginDTO.Password);
            if(user != null)
            {
                var token = this.tokenGenerator.GenerateToken(user.Username, user.Role);
                return Ok(new { token = token });
            }
            return Unauthorized("Invalid Credentials");
        }

        [Authorize]
        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {
            var user = await _userRepository.GetUserInfoAsync(userId);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if(users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }
    }
}
