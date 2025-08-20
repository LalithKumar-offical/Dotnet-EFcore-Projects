using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using praticerolebasedauthorization.Models;

namespace praticerolebasedauthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class WebseriesController : ControllerBase
    {
        private readonly CodeContext _context;

        public WebseriesController(CodeContext context)
        {
            _context = context;
        }

        // GET: api/Webseries
        [HttpGet]
        [Authorize(Roles="boss")]
        public async Task<ActionResult<IEnumerable<Webseries>>> GetDbWebSeries()
        {
            return await _context.DbWebSeries.ToListAsync();
        }

        // GET: api/Webseries/5
        [HttpGet("{id}")]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<Webseries>> GetWebseries(int? id)
        {
            var webseries = await _context.DbWebSeries.FindAsync(id);

            if (webseries == null)
            {
                return NotFound();
            }

            return webseries;
        }

        // PUT: api/Webseries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "boss")]
        public async Task<IActionResult> PutWebseries(int? id, Webseries webseries)
        {
            if (id != webseries.webseriesId)
            {
                return BadRequest();
            }

            _context.Entry(webseries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebseriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Webseries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "boss")]
        public async Task<ActionResult<Webseries>> PostWebseries(Webseries webseries)
        {
            _context.DbWebSeries.Add(webseries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebseries", new { id = webseries.webseriesId }, webseries);
        }

        // DELETE: api/Webseries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "boss")]
        public async Task<IActionResult> DeleteWebseries(int? id)
        {
            var webseries = await _context.DbWebSeries.FindAsync(id);
            if (webseries == null)
            {
                return NotFound();
            }

            _context.DbWebSeries.Remove(webseries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebseriesExists(int? id)
        {
            return _context.DbWebSeries.Any(e => e.webseriesId == id);
        }
    }
}
