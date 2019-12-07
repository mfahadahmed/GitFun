using AutoMapper;
using GitFun.API.DTOs;
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
        private readonly IMapper _mapper;

        private static readonly int[] ImageIdsArray = { 1020, 1024, 1074, 1003, 200 };

        public RegisterUserCommandHandler(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userRegister = request.UserRegisterDTO;
            if (await _authRepository.UserExists(userRegister.Username))
                throw new Exception("User already exists. Registration failed.");

            var user = _mapper.Map<UserRegisterDTO, User>(userRegister);

            var rd = new Random();
            int randomImageId = ImageIdsArray[rd.Next(0, ImageIdsArray.Length)];
            user.PhotoUrl = "https://picsum.photos/id/" + randomImageId + "/200/250";

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
