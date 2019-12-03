using GitFun.API.Models;
using MediatR;

namespace GitFun.API.Requests.Commands
{
    public class CreateRepoCommand : IRequest<string>
    {
        public Repository Repository { get; set; }
    }

    public class UpdateRepoCommand : IRequest
    {
        public string Id { get; set; }
        public Repository Repository { get; set; }
    }

    public class DeleteRepoCommand : IRequest
    {
        public string Id { get; set; }
    }
}
