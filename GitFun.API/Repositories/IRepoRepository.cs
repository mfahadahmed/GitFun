using GitFun.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Repositories
{
    public interface IRepoRepository
    {
        public Task<List<Repository>> GetList();
        public Task<Repository> GetById(string id);
        public Task Create(Repository repository);
        public Task Update(string id, Repository repository);
        public Task Remove(string id);
    }
}
