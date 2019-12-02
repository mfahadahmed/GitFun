using GitFun.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Repositories
{
    public interface IRepoRepository
    {
        Task<List<Repository>> GetList();
        Task<List<Repository>> GetList(List<string> ids);
        Task<Repository> GetById(string id);
        Task Create(Repository repository);
        Task Update(string id, Repository repository);
        Task Remove(string id);
    }
}
