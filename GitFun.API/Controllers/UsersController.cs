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
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersList = await _mediator.Send(new GetUsersQuery());
            return Ok(usersList);
        }

        [HttpGet("{id}", Name="GetUser")]
        public async Task<IActionResult> Get(string id)
        {
            var userDetails = await _mediator.Send(new GetUserDetailsQuery { UserId = id });
            return Ok(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                var userId = await _mediator.Send(new CreateUserCommand { User = user });
                return CreatedAtRoute("GetUser", new { Id = userId }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(string id, User user)
        {
            try
            {
                await _mediator.Send(new UpdateUserCommand { Id = id, User = user });
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
                await _mediator.Send(new DeleteUserCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}