using APIUser.Models;
using APIUser.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIUser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<List<User>> Get() =>
            await _userService.GetAsync();
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _userService.GetAsync(id);
            //return Ok(user);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            await _userService.CreateAsync(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.id }, newUser);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updateUser)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
                return NotFound();
            updateUser.id = user.id;
            await _userService.UpdateAsync(id, updateUser);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
                return NotFound();
            await _userService.RemoveAsync(id);
            return NoContent();
        }
        [HttpGet("byEmail")]
        public async Task<ActionResult<User>> GetByEmail([FromQuery] string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}
