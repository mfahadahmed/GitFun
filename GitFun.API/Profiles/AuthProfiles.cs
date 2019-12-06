using AutoMapper;
using GitFun.API.DTOs;
using GitFun.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Profiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            CreateMap<User, UserRegisterDTO>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<UserRegisterDTO, User>();
        }
    }
}
