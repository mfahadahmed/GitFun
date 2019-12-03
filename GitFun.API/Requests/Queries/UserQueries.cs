using GitFun.API.DTOs;
using MediatR;
using System.Collections.Generic;

namespace GitFun.API.Requests.Queries
{
    public class GetUsersQuery : IRequest<List<UserListDTO>>
    {
        public List<string> UserIds { get; set; }
    }

    public class GetUserDetailsQuery : IRequest<UserDetailsDTO>
    {
        public string UserId { get; set; }
    }
}
