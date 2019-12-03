using GitFun.API.Models;
using GitFun.API.Repositories;
using GitFun.API.Requests.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GitFun.API.Requests.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IAuthRepository _authRepository;

        public RegisterUserCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userRegister = request.UserRegisterDTO;
            if (await _authRepository.UserExists(userRegister.Username))
                throw new Exception("User already exists. Registration failed.");

            var user = new User { Username = userRegister.Username, Name = userRegister.Name ?? userRegister.Username };
            await _authRepository.Register(user, userRegister.Password);
            
            return Unit.Value;
        }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public LoginUserCommandHandler(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var loginUser = request.UserLoginDTO;
            
            var user = await _authRepository.Login(loginUser.Username, loginUser.Password);
            if (user == null)
                throw new Exception("The provided username or password is incorrect");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var tokenSection = _configuration.GetSection("AppSettings:Token").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSection));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
