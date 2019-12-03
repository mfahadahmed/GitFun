using System;
using System.Threading.Tasks;
using GitFun.API.DTOs;
using GitFun.API.Repositories;
using GitFun.API.Requests.Commands;
using MediatR;
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
        private readonly IMediator _mediator;

        public AuthController(IAuthRepository authRepository, IConfiguration config, IMediator mediator)
        {
            _authRepository = authRepository;
            _config = config;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO request)
        {
            try
            {
                await _mediator.Send(new RegisterUserCommand { UserRegisterDTO = request });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO request)
        {
            try
            {
                var userToken = await _mediator.Send(new LoginUserCommand { UserLoginDTO = request });
                return Ok(new { token = userToken });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}