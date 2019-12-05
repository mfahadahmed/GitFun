using GitFun.API.Models;
using System.Collections.Generic;

namespace GitFun.API.DTOs
{
    public class UserListDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
    }

    public class UserDetailsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Project> Projects { get; set; }
        public List<Repository> Repositories { get; set; }
    }
}
