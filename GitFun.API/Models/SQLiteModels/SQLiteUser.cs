using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Models.SQLiteModels
{
    public class SQLiteUser
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public List<Project> Projects { get; set; }

        public List<string> Repositories { get; set; }
    }

    public class SQLiteProject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Url { get; set; }
    }
}
