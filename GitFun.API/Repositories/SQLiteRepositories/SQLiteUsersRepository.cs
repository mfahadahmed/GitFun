using GitFun.API.Models.SQLiteModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitFun.API.Repositories.SQLiteRepositories
{
    public class SQLiteUsersRepository : ISQLiteUsersRepository
    {
        private readonly SQLiteDatabaseContext _context;

        public SQLiteUsersRepository(SQLiteDatabaseContext context) => _context = context;

        public async Task<List<SQLiteUser>> GetList() => await _context.SQLiteUsers.ToListAsync();

        public async Task<SQLiteUser> GetById(string id) => await _context.SQLiteUsers.FirstOrDefaultAsync();

        public async Task Create(SQLiteUser user)
        {
            await _context.SQLiteUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(string id, SQLiteUser user)
        {
            _context.SQLiteUsers.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            _context.Remove(GetById(id));
            await _context.SaveChangesAsync();
        }
    }
}
