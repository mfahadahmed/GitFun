using System.Collections.Generic;
using System.Threading.Tasks;
using GitFun.API.Models;
using GitFun.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitFun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService) => _userService = userService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersList = await _userService.Get();
            return Ok(usersList);
        }

        [HttpGet("{id}", Name="GetUser")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var createdUser = await _userService.Create(user);
            return CreatedAtRoute("GetUser", new { Id = createdUser.Id }, createdUser);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(string id, User user)
        {
            var recordFound = await _userService.Get(id);
            if (recordFound == null)
            {
                return NotFound();
            }

            var updated = await _userService.Update(id, user);
            return Ok(updated);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var recordFound = await _userService.Get(id);
            if (recordFound == null)
            {
                return NotFound();
            }

            var deleted = await _userService.Remove(id);
            return Ok(deleted);
        }

    }
}