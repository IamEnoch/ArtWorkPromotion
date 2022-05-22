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
    public class ArtistsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArtistsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetUsers()
        {
            return await _context.Users
                .Select(u=>new Artist(u.FirstName, u.LastName, u.Email, u.PhoneNumber, u.Id))
                .ToListAsync();
        }

        // GET: api/Artists/a40ac323-d0a4-460d-bc66-81fe2c6c3da0
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetAppUser(Guid id)
        {
            var appUser = await _context.Users.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return new Artist(appUser.FirstName, appUser.LastName, appUser.Email, appUser.PhoneNumber, appUser.Id);
        }

        // PUT: api/Artists/a40ac323-d0a4-460d-bc66-81fe2c6c3da0
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(Guid id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }

            var appUser = await _context.Users.FindAsync(id);

            if(appUser is null)
            {
                return NotFound("No artist was found with the provided Id");
            }

            appUser.FirstName = artist.FirstName;
            appUser.LastName = artist.LastName;
            appUser.Email = artist.Email;
            appUser.PhoneNumber = artist.PhoneNumber;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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

        private bool AppUserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
