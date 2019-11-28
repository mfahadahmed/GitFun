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
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository) => _userRepository = userRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersList = await _userRepository.GetList();
            return Ok(usersList);
        }

        [HttpGet("{id}", Name="GetUser")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userRepository.Create(user);
            return CreatedAtRoute("GetUser", new { Id = user.Id }, user);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(string id, User user)
        {
            var existingUser = await _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.Id = existingUser.Id;
            await _userRepository.Update(id, user);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingUser = await _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userRepository.Remove(id);
            return NoContent();
        }
    }
}