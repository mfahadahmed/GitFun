using System.Collections.Generic;
using System.Threading.Tasks;
using GitFun.API.Models;
using GitFun.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GitFun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UsersController(IUserRepository userService) => _userService = userService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersList = await _userService.GetList();
            return Ok(usersList);
        }

        [HttpGet("{id}", Name="GetUser")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.Create(user);
            return CreatedAtRoute("GetUser", new { Id = user.Id }, user);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(string id, User user)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.Update(id, user);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.Remove(id);
            return NoContent();
        }

    }
}