using System.Threading.Tasks;
using GitFun.API.Models;
using GitFun.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GitFun.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepoRepository _repoRepository;

        public RepositoryController(IRepoRepository repoRepository) => _repoRepository = repoRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reposList = await _repoRepository.GetList();
            return Ok(reposList);
        }

        [HttpGet("{id}", Name = "GetRepository")]
        public async Task<IActionResult> Get(string id)
        {
            var repository = await _repoRepository.GetById(id);
            if (repository == null)
            {
                return NotFound();
            }

            return Ok(repository);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Repository repository)
        {
            await _repoRepository.Create(repository);
            return CreatedAtRoute("GetRepository", new { Id = repository.Id }, repository);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(string id, Repository repository)
        {
            var existingRepo = await _repoRepository.GetById(id);
            if (existingRepo == null)
                return NotFound();

            repository.Id = existingRepo.Id;
            await _repoRepository.Update(id, repository);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingRepo = await _repoRepository.GetById(id);
            if (existingRepo == null)
            {
                return NotFound();
            }

            await _repoRepository.Remove(id);
            return NoContent();
        }
    }
}