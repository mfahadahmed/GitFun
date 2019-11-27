using System.Collections.Generic;
using System.Threading.Tasks;
using GitFun.API.Models;

namespace GitFun.API.Repositories
{
    public interface IUserRepository
    {
         public Task<List<User>> GetList();
         public Task<User> GetById(string id);
         public Task Create(User user);
         public Task Update(string id, User user);
         public Task Remove(string id);
    }
}