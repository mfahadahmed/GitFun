using GitFun.API.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Requests.Queries
{
    public class GetReposQuery : IRequest<List<RepoListDTO>>
    {
        public List<string> Ids { get; set; }
    }

    public class GetRepoDetailsQuery : IRequest<RepoDetailsDTO>
    {
        public string Id { get; set; }
    }
}
