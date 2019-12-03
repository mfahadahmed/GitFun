using AutoMapper;
using GitFun.API.DTOs;
using GitFun.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
