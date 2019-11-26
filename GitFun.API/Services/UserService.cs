using System.Collections.Generic;
using System.Threading.Tasks;
using GitFun.API.Models;
using MongoDB.Driver;

namespace GitFun.API.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IGitFunDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<List<User>> Get()
        {
            var users = await _users.FindAsync(user => true);
            return await users.ToListAsync();
        }

        public async Task<User> Get(string id)
        {
            var user = await _users.FindAsync(user => user.Id == id);
            return user.FirstOrDefault();
        }

        public async Task<User> Create(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<ReplaceOneResult> Update(string id, User user)
        {
            user.Id = id;
            return await _users.ReplaceOneAsync(us => us.Id == id, user);
        }

        public async Task<DeleteResult> Remove(string id) => await _users.DeleteOneAsync(user => user.Id == id);
    }
}