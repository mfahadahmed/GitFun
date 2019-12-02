using GitFun.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.DTOs
{
    public class UserListDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }

    public class UserDetailsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Project> Projects { get; set; }
        public List<Repository> Repositories { get; set; }
    }
}
