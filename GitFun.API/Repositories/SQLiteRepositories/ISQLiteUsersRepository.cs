using GitFun.API.Models.SQLiteModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitFun.API.Repositories.SQLiteRepositories
{
    public interface ISQLiteUsersRepository
    {
        public Task<List<SQLiteUser>> GetList();
        public Task<SQLiteUser> GetById(string id);
        public Task Create(SQLiteUser user);
        public Task Update(string id, SQLiteUser user);
        public Task Remove(string id);
    }
}
