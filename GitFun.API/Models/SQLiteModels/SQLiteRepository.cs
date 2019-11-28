using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Models.SQLiteModels
{
    public class SQLiteRepository
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public string Url { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
