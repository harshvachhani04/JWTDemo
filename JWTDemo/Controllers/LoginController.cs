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
        private readonly ILogger<LoginController> _logger;
        private readonly JwtTokenGenerator tokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginController(ILogger<LoginController> logger, JwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            this._logger = logger;
            this.tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("IsAvailable")]
        public async Task<bool> IsAvaialble()
        {
            return true;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                UserDemo user = await _userRepository.GetUserAsync(loginDTO.Username, loginDTO.Password);
                if (user != null)
                {
                    _logger.LogInformation("User Found");
                    var token = this.tokenGenerator.GenerateToken(user.Username, user.Role);
                    return Ok(new { token = token });
                }
                _logger.LogWarning("Invalid Credentials");
                return Unauthorized("Invalid Credentials");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Login User, {ex.Message} {ex}", ex);
                return NoContent();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {
            var user = await _userRepository.GetUserInfoAsync(userId);
            if(user != null)
                return Ok(user);
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if(users != null)
                return Ok(users);
            return NotFound();
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> RegisterNewUserAsyc(UserDemo newUser)
        {
            var user = await _userRepository.IsUserExistAsync(newUser.Username);
            if(!user)
            {
                var newUserId = await _userRepository.RegisterNewUserAsyc(newUser);
                return CreatedAtAction(nameof(GetUserInfo), new { userId = newUserId }, newUser);
            }
            return Conflict( new { StatusCode = 409, error = "Conflict", message ="User already exist" });
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync(UserDemo updatedUser)
        {
            var isUserExist = await _userRepository.IsUserExistAsync(updatedUser.Username);
            if(isUserExist)
            {
                var result = await _userRepository.UpdateUserAsync(updatedUser);
                if(result)
                    return Ok(result);
                return StatusCode(500);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetUserInfoAsync(userId);
            if (user != null)
            {
                var sucess = await _userRepository.DeleteUserAsync(user);
                if(sucess)
                    return Ok(user);
                return StatusCode(500);
            }
            return NotFound();
        }
    }
}
