using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtWorkPromotion.API.Data;
using ArtWorkPromotion.API.Models;
using ArtWorkPromotion.PCL.Models;

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
        public async Task<ActionResult<IEnumerable<NewSocial>>> GetSocial()
        {
          if (_context.Social == null)
          {
              return NotFound();
          }

            var social = await _context.Social.Select(x => new NewSocial(x.WhatsApp, x.Facebook, x.Instagram, x.Pintrest, x.AppUserId)).ToListAsync();
            return Ok(social);


            //return await _context.Social.ToListAsync();
        }

        // GET: api/Socials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewSocial>> GetSocial(Guid id)
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

            var newSocial = await _context.Social.Select(x => new NewSocial(x.WhatsApp, x.Facebook, x.Instagram, x.Pintrest, x.AppUserId)).ToListAsync();
            return Ok(newSocial);
        }

        // PUT: api/Socials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocial(Guid id, [FromBody]NewSocial newSocial)
        {
            if (id != newSocial.Id)
            {
                return BadRequest();
            }

            _context.Entry(newSocial).State = EntityState.Modified;

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
        /*[HttpPost]
        public async Task<ActionResult<Social>> PostSocial(NewSocial newSocial)
        {
          if (_context.Social == null)
          {
              return Problem("Entity set 'AppDbContext.Social'  is null.");
          }
            _context.Social.Add(newSocial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocial", new { id = social.Id }, social);
        }*/

        //Post: api/Socials/5b95d220-b28c-48da-8307-7856ec15b753
        [HttpPost]
        public async Task<ActionResult<NewSocial>> PostSocial(Guid id, [FromBody]NewSocial newSocial)
        {
            if (!SocialExists(id))
            {
                return NotFound();
            }

            var appUser = _context.Users.FindAsync(id);

            var social = new Social(newSocial.WhatsApp, newSocial.Facebook, newSocial.Instagram, newSocial.Pintrest)
            {
                AppUserId = id,
                AppUser = appUser.Result
            };

            _context.Social.Add(social);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post Social", new {id = id}, social);

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

            return Ok("Deleted successfully");
        }

        private bool SocialExists(Guid id)
        {
            return (_context.Social?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
