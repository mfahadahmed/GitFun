using AutoMapper;
using GitFun.API.DTOs;
using GitFun.API.Models;

namespace GitFun.API.Profiles
{
    public class RepositoryProfiles : Profile
    {
        public RepositoryProfiles()
        {
            CreateMap<Repository, RepoListDTO>();
            CreateMap<Repository, RepoDetailsDTO>();
        }
    }
}
