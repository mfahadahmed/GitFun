using System.Security.Claims;
using System.Threading.Tasks;
using GitFun.API.DTOs;
using GitFun.API.Models;
using GitFun.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GitFun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            if (await _authRepository.UserExists(dto.Username))
                return BadRequest("User already exists");

            var user = new User { Username = dto.Username };
            var createdUser = await _authRepository.Register(user, dto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            var user = await _authRepository.GetUser(dto.Username);
            if (user == null)
                return Unauthorized();

            if (!_authRepository.Login(user, dto.Password))
                return Unauthorized();

            var claims = new []
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey()

        }
    }
}