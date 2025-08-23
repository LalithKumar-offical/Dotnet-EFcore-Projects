using API_Assessment.Data;
using API_Assessment.Models;
using API_Assessment.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebseriesController : ControllerBase
    {
        private readonly Genericservice<WebseriesClass, string> _genericservice;
        private readonly CodeContextData _context; // Inject the DbContext to perform a specialized query.

        public WebseriesController(Genericservice<WebseriesClass, string> genericservice, CodeContextData context)
        {
            _genericservice = genericservice;
            _context = context; // Initialize the DbContext
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _genericservice.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
          (await _genericservice.GetById(id)) is var entity && entity == null ? NotFound() : Ok(entity);

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WebseriesClass webseries)
        {
            if (webseries == null) return BadRequest();

            var allWebseries = await _genericservice.GetAll();
            var lastId = allWebseries
              .Where(w => w.WebseriesId.StartsWith("Web_"))
              .Select(w => int.TryParse(w.WebseriesId.Substring(4), out var num) ? num : 0)
              .DefaultIfEmpty(100)
              .Max();

            webseries.WebseriesId = $"Web_{lastId + 1}";

            await _genericservice.Add(webseries);
            await _genericservice.SavetoDB();

            return CreatedAtAction(nameof(GetById), new { id = webseries.WebseriesId }, webseries);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] WebseriesClass webseries)
        {
            if (webseries == null || webseries.WebseriesId != id) return BadRequest();
            await _genericservice.Update(webseries);
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

        [HttpGet("AllDetails/{id}")]
        public async Task<IActionResult> GetWebseriesDetailsById(string id)
        {
            try
            {
                var webseries = await _genericservice.GetWebseriesDetailsById(id);
                if (webseries == null) return NotFound();
                return Ok(webseries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
}
    }
