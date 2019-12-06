using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.DTOs
{
    public class RepoListDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Owner { get; set; }
    }

    public class RepoDetailsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Owner { get; set; }
        public List<string> Branches { get; set; }
        public List<string> Commits { get; set; }
        public bool IsPublic { get; set; }
        public bool IsStarred { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
