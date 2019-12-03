using System.Collections.Generic;
using System.Threading.Tasks;
using GitFun.API.Models;

namespace GitFun.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetList();
        Task<User> GetById(string id);
        Task<User> GetByUsername(string username);
        Task<string> GetRepoOwner(string repoId);
        Task Create(User user);
        Task Update(string id, User user);
        Task Remove(string id);
    }
}