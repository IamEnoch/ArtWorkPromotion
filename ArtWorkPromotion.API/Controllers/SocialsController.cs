using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtWorkPromotion.API.Data;
using ArtWorkPromotion.API.Models;

namespace ArtWorkPromotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SocialsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Socials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Social>>> GetSocial()
        {
          if (_context.Social == null)
          {
              return NotFound();
          }
            return await _context.Social.ToListAsync();
        }

        // GET: api/Socials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Social>> GetSocial(Guid id)
        {
          if (_context.Social == null)
          {
              return NotFound();
          }
            var social = await _context.Social.FindAsync(id);

            if (social == null)
            {
                return NotFound();
            }

            return social;
        }

        // PUT: api/Socials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocial(Guid id, Social social)
        {
            if (id != social.Id)
            {
                return BadRequest();
            }

            _context.Entry(social).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialExists(id))
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

        // POST: api/Socials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Social>> PostSocial(Social social)
        {
          if (_context.Social == null)
          {
              return Problem("Entity set 'AppDbContext.Social'  is null.");
          }
            _context.Social.Add(social);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocial", new { id = social.Id }, social);
        }

        // DELETE: api/Socials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocial(Guid id)
        {
            if (_context.Social == null)
            {
                return NotFound();
            }
            var social = await _context.Social.FindAsync(id);
            if (social == null)
            {
                return NotFound();
            }

            _context.Social.Remove(social);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SocialExists(Guid id)
        {
            return (_context.Social?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
