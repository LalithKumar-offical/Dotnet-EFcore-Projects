using API_Assessment.Models;
using API_Assessment.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly Genericservice<SeasonsClass, string> _genericservice;

        public SeasonsController(Genericservice<SeasonsClass, string> genericservice)
        {
            _genericservice = genericservice;
        }

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _genericservice.GetAll());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
            (await _genericservice.GetById(id)) is var entity && entity == null ? NotFound() : Ok(entity);

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SeasonsClass season)
        {
            if (season == null) return BadRequest();

            var allSeasons = await _genericservice.GetAll();
            var lastId = allSeasons
                .Where(s => s.SeasonId.StartsWith("S"))
                .Select(s => int.TryParse(s.SeasonId.Substring(1), out var num) ? num : 0)
                .DefaultIfEmpty(100)
                .Max();

            season.SeasonId = $"S{lastId + 1}";

            await _genericservice.Add(season);
            await _genericservice.SavetoDB();
            return CreatedAtAction(nameof(GetById), new { id = season.SeasonId }, season);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SeasonsClass season)
        {
            if (season == null || season.SeasonId != id) return BadRequest();
            await _genericservice.Update(season);
            await _genericservice.SavetoDB();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _genericservice.Delete(id);
            await _genericservice.SavetoDB();
            return NoContent();
        }
    }
}
