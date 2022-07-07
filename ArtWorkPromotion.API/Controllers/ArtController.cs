using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtWorkPromotion.API.Data;
using ArtWorkPromotion.API.Models;
using ArtWorkPromotion.PCL.Models;
using ArtWorkPromotion.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ArtWorkPromotion.PCL.Helpers;

namespace ArtWorkPromotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly AppDbContext _context;
        //private readonly IBlobStorageService _blobStorageService;
        private string artContainerName = "arts";


        public ArtController(AppDbContext context)
        {
            _context = context;
            //_blobStorageService = blobStorageService;
        }

        // GET: api/Art
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtWork>>> GetArts()
        {
            List<ArtWork> arts = new List<ArtWork>();

            //Query that does an inner join of art table and appUser table
            var query = from art in _context.Set<Art>()
                        join appUser in _context.Set<AppUser>()
                            on art.AppUserId equals appUser.Id
                        select new { art, appUser };
                      

            foreach(var artWork in query)
            {
                var artResult = new ArtWork
                {
                    Id = artWork.art.Id,
                    Name = artWork.art.Name,
                    Description = artWork.art.Description,
                    ArtistId = artWork.appUser.Id,
                    Price = artWork.art.Price,
                    Category = artWork.art.Category,
                    ArtImageUrl = artWork.art.ArtImageUrl

                };

                arts.Add(artResult);
            }           

            /*var response = await _context.Arts
                .Join(_context.Users, a => a.AppUserId, u => u.Id, (a, u) => new { a, u })
                .Select(x => new ArtWork(x.a.Id, x.a.Name,
                        x.a.Description, x.u.Name,
                        x.u.Id, x.a.Price, x.a.Category,
                        _blobStorageService.GetArtImages("arts", x.a.StoragePath, x.u.Id.ToString())))
                .ToListAsync();*/

            return arts;
        }

        //GET: api/Art/category/drawing
        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<ArtWork>>> GetArtByCategory(Category category)
        {
            List<ArtWork> arts = new List<ArtWork>();

            //Query that does an inner join of art table and appUser table
            var query = from art in _context.Set<Art>()
                        join appUser in _context.Set<AppUser>()
                            on art.AppUserId equals appUser.Id
                            where art.Category == category
                        select new { art, appUser };


            foreach (var artWork in query)
            {
                var artResult = new ArtWork
                {
                    Id = artWork.art.Id,
                    Name = artWork.art.Name,
                    Description = artWork.art.Description,
                    ArtistId = artWork.appUser.Id,
                    Price = artWork.art.Price,
                    Category = artWork.art.Category,
                    ArtImageUrl = artWork.art.ArtImageUrl

                };

                arts.Add(artResult);
            }

            return arts;
            /*return await _context.Arts.Where(a=>a.Category==category)
                .Join(_context.Users, a => a.AppUserId, u => u.Id, (a, u) => new { a, u })
                .Select(x => new ArtWork(x.a.Id, x.a.Name,
                        x.a.Description, x.u.Name,
                        x.u.Id, x.a.Price, x.a.Category,
                        _blobStorageService.GetArtImages("arts", x.a.StoragePath, x.a.Id.ToString())))
                .ToListAsync();*/
        }

        //GET: api/Art/artist/a40ac323-d0a4-460d-bc66-81fe2c6c3da0
        [HttpGet("artist/{artistId}")]
        public async Task<ActionResult<IEnumerable<ArtWork>>> GetArtByArtistId(Guid artistId)
        {

            List<ArtWork> arts = new List<ArtWork>();

            //Query that does an inner join of art table and appUser table
            var query = from art in _context.Set<Art>()
                        join appUser in _context.Set<AppUser>()
                            on art.AppUserId equals appUser.Id
                            where appUser.Id == artistId
                        select new { art, appUser };


            foreach (var artWork in query)
            {
                var artResult = new ArtWork
                {
                    Id = artWork.art.Id,
                    Name = artWork.art.Name,
                    Description = artWork.art.Description,
                    ArtistId = artWork.appUser.Id,
                    Price = artWork.art.Price,
                    Category = artWork.art.Category,
                    ArtImageUrl = artWork.art.ArtImageUrl
                };

                arts.Add(artResult);
            }

            return arts;
            /*return await _context.Arts
                .Join(_context.Users.Where(u => u.Id == artistId), a => a.AppUserId, u => u.Id, (a, u) => new { a, u })
                .Select(x => new ArtWork(x.a.Id, x.a.Name,
                        x.a.Description, x.u.Name,
                        x.u.Id, x.a.Price, x.a.Category,
                        _blobStorageService.GetArtImages("arts", x.a.StoragePath, x.u.Id.ToString())))
                .ToListAsync();*/
        }


        // GET: api/Art/a40ac323-d0a4-460d-bc66-81fe2c6c3da0
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtWork>> GetArt(Guid id)
        {
            var art = await _context.Arts.FindAsync(id);

            if (art == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(art.AppUserId);

            var result = new ArtWork(art.Id,
                               art.Name,
                               art.Description,
                               user.Id,
                               art.Price,
                               art.Category,
                               art.ArtImageUrl
                               );

            return result;
        }

        // PUT: api/Art/a40ac323-d0a4-460d-bc66-81fe2c6c3da0
        [HttpPut("{id}")]
       // [Authorize]
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
            art.Name = artWork.Name;
            art.Price = artWork.Price;
            art.ArtImageUrl = artWork.ArtImageUrl;

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

        //GET: api/Art/blobUpload/a40ac323-d0a4-460d-bc66-81fe2c6c3da0
        /*[HttpGet("blobUpload/{artId}")]
        [Authorize]
        public async Task<ActionResult<BlobUpload>> GetblobUploadInfo(Guid artId)
        {
            var art = await _context.Arts.FindAsync(artId);
            if(art is null)
            {
                return NotFound("No art was found with the provided Id");
            }

            var container = await _blobStorageService.CreateContainerAsync(artContainerName);
            if (container != null)
            {
                var blobUpload = new BlobUpload()
                {
                    ConatinerName=container.ConatinerName,
                    ContainerUrl=container.ContainerUrl,
                    Prefix= $"{art.AppUserId}/{art.StoragePath}",
                    ConnectionString=container.ConnectionString,
                    TokenExpiry=container.TokenExpiry      
                };

                return Ok(blobUpload);
            }
            return StatusCode(500);

        }*/

        // POST: api/Art
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ArtWork>> PostArt([FromBody]NewArt newArt)
        {
            //var uniqueStoragePath = $"{DateTime.Now.ToString("yyMMddHHmmss")}{newArt.Name}";
            var art = new Art(newArt.Name, newArt.Description, newArt.Price, newArt.Category, newArt.ArtistId, newArt.ArtImageUrl);
            _context.Arts.Add(art);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArt", new { id = art.Id }, art);
        }

        // DELETE: api/Art/a40ac323-d0a4-460d-bc66-81fe2c6c3da0
        [HttpDelete("{id}")]
      //  [Authorize]
        public async Task<IActionResult> DeleteArt(Guid id)
        {
            var art = await _context.Arts.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }

            _context.Arts.Remove(art);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully");
        }

        private bool ArtExists(Guid id)
        {
            return _context.Arts.Any(e => e.Id == id);
        }
    }
}
