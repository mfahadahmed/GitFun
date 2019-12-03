using System;
using System.Threading.Tasks;
using GitFun.API.Models;
using GitFun.API.Repositories;
using GitFun.API.Requests.Commands;
using GitFun.API.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GitFun.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepoRepository _repoRepository;
        private readonly IMediator _mediator;

        public RepositoryController(IRepoRepository repoRepository, IMediator mediator)
        {
            _repoRepository = repoRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var reposList = await _mediator.Send(new GetReposQuery());
                return Ok(reposList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetRepository")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var repository = await _mediator.Send(new GetRepoDetailsQuery { Id = id });
                return Ok(repository);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Repository repository)
        {
            try
            {
                await _mediator.Send(new CreateRepoCommand { Repository = repository });
                return CreatedAtRoute("GetRepository", new { Id = repository.Id }, repository);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(string id, Repository repository)
        {
            try
            {
                await _mediator.Send(new UpdateRepoCommand { Id = id, Repository = repository });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _mediator.Send(new DeleteRepoCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}