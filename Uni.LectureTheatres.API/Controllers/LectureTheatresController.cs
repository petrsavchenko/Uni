using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uni.LectureTheatres.DataAccess;
using Uni.LectureTheatres.Domain;

namespace Uni.LectureTheatres.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LectureTheatresController : ControllerBase
    {
        private readonly LectureTheatreDbContext _context;

        public LectureTheatresController(LectureTheatreDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/LectureTheatres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LectureTheatre>>> GetLectureTheatres()
        {
            return await _context.LectureTheatres.ToListAsync();
        }

        // GET: api/v1/LectureTheatres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LectureTheatre>> GetLectureTheatre(Guid id)
        {
            var lectureTheatre = await _context.LectureTheatres.FindAsync(id);

            if (lectureTheatre == null)
            {
                return NotFound();
            }

            return lectureTheatre;
        }

        // PUT: api/v1/LectureTheatres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLectureTheatre(Guid id, LectureTheatre lectureTheatre)
        {
            if (id != lectureTheatre.Id)
            {
                return BadRequest();
            }

            _context.Entry(lectureTheatre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureTheatreExists(id))
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

        // POST: api/v1/LectureTheatres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LectureTheatre>> PostLectureTheatre(LectureTheatre lectureTheatre)
        {
            _context.LectureTheatres.Add(lectureTheatre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLectureTheatre", new { id = lectureTheatre.Id }, lectureTheatre);
        }

        // DELETE: api/v1/LectureTheatres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLectureTheatre(Guid id)
        {
            var lectureTheatre = await _context.LectureTheatres.FindAsync(id);
            if (lectureTheatre == null)
            {
                return NotFound();
            }

            _context.LectureTheatres.Remove(lectureTheatre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LectureTheatreExists(Guid id)
        {
            return _context.LectureTheatres.Any(e => e.Id == id);
        }
    }
}
