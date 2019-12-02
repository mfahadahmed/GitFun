using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitFun.API.Models;
using MongoDB.Driver;

namespace GitFun.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IGitFunDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<List<User>> GetList()
        {
            var users = await _users.FindAsync(user => true);
            return await users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            var user = await _users.FindAsync(user => user.Id == id);
            return await user.FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            var user = await _users.FindAsync(user => user.Username == username);
            return await user.FirstOrDefaultAsync();
        }

        public async Task Create(User user)
        {
            if (user.Projects?.Count > 0)
            {
                foreach (var project in user.Projects)
                    project.LastUpdated = DateTime.Now;
            }

            await _users.InsertOneAsync(user);
        }

        public async Task Update(string id, User user) => await _users.ReplaceOneAsync(us => us.Id == id, user);

        public async Task Remove(string id) => await _users.DeleteOneAsync(user => user.Id == id);
    }
}