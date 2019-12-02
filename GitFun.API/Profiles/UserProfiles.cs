using AutoMapper;
using GitFun.API.DTOs;
using GitFun.API.Models;

namespace GitFun.API.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserListDTO>();
            CreateMap<User, UserDetailsDTO>().ForMember(x => x.Repositories, opt => opt.Ignore());
        }
    }
}
