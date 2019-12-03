using GitFun.API.DTOs;
using MediatR;

namespace GitFun.API.Requests.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public UserRegisterDTO UserRegisterDTO { get; set; }
    }

    public class LoginUserCommand : IRequest<string>
    {
        public UserLoginDTO UserLoginDTO { get; set; }
    }
}
