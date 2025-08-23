using API_Assessment.Models;
using API_Assessment.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Genericservice<UserClass, int> _genericservice;

        public UserController(Genericservice<UserClass, int> genericservice)
        {
            _genericservice = genericservice;
        }

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _genericservice.GetAll());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            (await _genericservice.GetById(id)) is var entity && entity == null ? NotFound() : Ok(entity);

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserClass user)
        {
            if (user == null) return BadRequest();
            await _genericservice.Add(user);
            await _genericservice.SavetoDB();
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserClass user)
        {
            if (user == null || user.UserId != id) return BadRequest();
            await _genericservice.Update(user);
            await _genericservice.SavetoDB();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericservice.Delete(id);
            await _genericservice.SavetoDB();
            return NoContent();
        }
    }
}
