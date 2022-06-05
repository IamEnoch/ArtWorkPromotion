using System;
using Microsoft.AspNetCore.Identity;

namespace ArtWorkPromotion.API.Models
{
	public class AppUser : IdentityUser<Guid>
	{
        public string? Name { get; set; } 

        public string? Description { get; set; }

        public string? Brand { get; set; }

        public string? Location { get; set; }

        public string? Address { get; set; }

        public virtual ICollection<Art> Arts { get; set; }
        public virtual Social Social { get; set; }
    }
}

