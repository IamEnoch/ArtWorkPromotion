using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtWorkPromotion.API.Data;
using ArtWorkPromotion.API.Models;
using ArtWorkPromotion.PCL.Models;

namespace ArtWorkPromotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArtController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Art
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtWork>>> GetArts()
        {
            return await _context.Arts
                .Join(_context.Users, a => a.AppUserId, u => u.Id, (a, u) => new { a, u })
                .Select(x => new ArtWork(x.a.Id, x.a.Name, x.a.Description, $"{x.u.FirstName} {x.u.LastName}", x.u.Id, x.a.Location, x.a.Price, x.a.Category, x.a.StoragePath))
                .ToListAsync();
        }

        // GET: api/Art/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtWork>> GetArt(Guid id)
        {
            var art = await _context.Arts.FindAsync(id);

            if (art == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(art.AppUserId);

            return new ArtWork(art.Id, art.Name, art.Description, $"{user?.FirstName} {user?.LastName}", user.Id, art.Location, art.Price, art.Category, art.StoragePath); ;
        }

        // PUT: api/Art/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArt(Guid id, ArtWork artWork)
        {
            if (id != artWork.Id)
            {
                return BadRequest();
            }

            var art = await _context.Arts.FindAsync(id);
            if(art==null)
            {
                return NotFound();
            }

            art.Category = artWork.Category;
            art.Description = artWork.Description;
            art.Location = artWork.Location;
            art.Name = artWork.Name;
            art.Price = artWork.Price;
            art.StoragePath = artWork.StoragePath;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtExists(id))
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

        // POST: api/Art
        [HttpPost]
        public async Task<ActionResult<ArtWork>> PostArt(ArtWork artWork)
        {
            var art = new Art(artWork.Name, artWork.Description, artWork.Price, artWork.Category, artWork.ArtistId, artWork.StoragePath, artWork.Location);
            _context.Arts.Add(art);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArt", new { id = art.Id }, art);
        }

        // DELETE: api/Art/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArt(Guid id)
        {
            var art = await _context.Arts.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }

            _context.Arts.Remove(art);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtExists(Guid id)
        {
            return _context.Arts.Any(e => e.Id == id);
        }
    }
}
