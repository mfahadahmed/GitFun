using GitFun.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitFun.API.Repositories
{
    public class RepoRepository : IRepoRepository
    {
        private readonly IMongoCollection<Repository> _repositories;

        public RepoRepository(IGitFunDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _repositories = database.GetCollection<Repository>(settings.RepositoriesCollectionName);
        }

        public async Task<List<Repository>> GetList()
        {
            var repositories = await _repositories.FindAsync(repository => true);
            return await repositories?.ToListAsync();
        }

        public async Task<List<Repository>> GetList(List<string> repoIds)
        {
            if (repoIds == null)
                return null;

            var filter = Builders<Repository>.Filter.In(repo => repo.Id, repoIds);
            var repos = await _repositories.FindAsync(filter);

            return await repos?.ToListAsync();
        }

        public async Task<Repository> GetById(string id)
        {
            var repository = await _repositories.FindAsync(repository => repository.Id == id);
            return await repository.FirstOrDefaultAsync();
        }

        public async Task Create(Repository repository)
        {
            repository.LastUpdated = DateTime.Now;
            await _repositories.InsertOneAsync(repository);
        }
        public async Task Update(string id, Repository repository)
        {
            repository.LastUpdated = DateTime.Now;
            await _repositories.ReplaceOneAsync(repo => repo.Id == id, repository);
        }

        public async Task Remove(string id) => await _repositories.DeleteOneAsync(repository => repository.Id == id);
    }
}
