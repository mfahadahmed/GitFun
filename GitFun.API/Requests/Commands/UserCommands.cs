using GitFun.API.Models;
using MediatR;

namespace GitFun.API.Requests.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public User User { get; set; }
    }

    public class UpdateUserCommand : IRequest
    {
        public string Id { get; set; }
        public User User { get; set; }
    }

    public class DeleteUserCommand : IRequest
    {
        public string Id { get; set; }
    }
}
