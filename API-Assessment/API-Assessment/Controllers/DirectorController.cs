using API_Assessment.Models;
using API_Assessment.Service;
using API_Assessment.Repositary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly Service.Genericservice<DirectorClass, String>? _genericservice;
        public DirectorController(Genericservice<DirectorClass, string>? genericservice)
        {
            _genericservice = genericservice;
        }
        [HttpGet]
        [Authorize(Roles = "admin,boss,customer")]

        public async Task<IActionResult> GetAllDirectors()
        {
            var directors = await _genericservice.GetAll();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        [Authorize(Roles="customer")]
        public async Task<IActionResult> GetDirectorById(string id)
        {
            var director = await _genericservice.GetById(id);
            if (director == null)
                return NotFound();

            return Ok(director);
        }

        [HttpPost]
        public async Task<IActionResult> AddDirector([FromBody] DirectorClass director)
        {
            if (director == null)
                return BadRequest();
            var allDirectors = await _genericservice.GetAll();
            int newNumber = 101;
            if (allDirectors.Any())
            {
                var maxNumber = allDirectors
                    .Select(d =>
                    {
                        if (d.DirectorId != null && d.DirectorId.StartsWith("Dir_"))
                        {
                            var numPart = d.DirectorId.Replace("Dir_", "");
                            return int.TryParse(numPart, out int n) ? n : 0;
                        }
                        return 0;
                    })
                    .Max();
                newNumber = maxNumber + 1;
            }
            director.DirectorId = $"Dir_{newNumber}";
            await _genericservice.Add(director);
            await _genericservice.SavetoDB();
            return CreatedAtAction(nameof(GetDirectorById), new { id = director.DirectorId }, director);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDirector(string id, [FromBody] DirectorClass director)
        {
            if (director == null || director.DirectorId != id)
                return BadRequest();

            await _genericservice.Update(director);
            await _genericservice.SavetoDB();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> DeleteDirector(string id)
        {
            await _genericservice.Delete(id);
            await _genericservice.SavetoDB();
            return NoContent();
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDirectorDetailsById(string id)
        {
            try
            {
                var directorDetails = await _genericservice.GetDirectorDetailsById(id);
                return Ok(directorDetails);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Experienced")]
        public async Task<IActionResult> GetExperiencedDirectors([FromQuery] int minExperience)
        {
            try
            {
                // Retrieve all directors first
                var allDirectors = await _genericservice.GetAll();

                // Then, perform the filtering and conversion in-memory
                var experiencedDirectors = allDirectors
                    .Where(d => int.TryParse(d.DirectorExperience, out var experienceValue) && experienceValue > minExperience)
                    .ToList();

                if (!experiencedDirectors.Any())
                {
                    return NotFound($"No directors found with more than {minExperience} years of experience.");
                }

                return Ok(experiencedDirectors);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
