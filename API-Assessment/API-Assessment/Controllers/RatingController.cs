using API_Assessment.Models;
using API_Assessment.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly Genericservice<RatingClass, string> _genericservice;

        public RatingController(Genericservice<RatingClass, string> genericservice)
        {
            _genericservice = genericservice;
        }

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _genericservice.GetAll());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
            (await _genericservice.GetById(id)) is var entity && entity == null ? NotFound() : Ok(entity);

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RatingClass rating)
        {
            if (rating == null) return BadRequest();

            var allRatings = await _genericservice.GetAll();
            var lastId = allRatings
                .Select(r => r.RatingId)
                .Where(id => id != null && Regex.IsMatch(id, @"R_\d+"))
                .OrderByDescending(id => int.Parse(id!.Split('_')[1]))
                .FirstOrDefault();

            int nextNumber = lastId != null ? int.Parse(lastId.Split('_')[1]) + 1 : 101;
            rating.RatingId = $"R_{nextNumber}";

            await _genericservice.Add(rating);
            await _genericservice.SavetoDB();

            return CreatedAtAction(nameof(GetById), new { id = rating.RatingId }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] RatingClass rating)
        {
            if (rating == null || rating.RatingId != id) return BadRequest();
            await _genericservice.Update(rating);
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
