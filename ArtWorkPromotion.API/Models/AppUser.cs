using System;
using Microsoft.AspNetCore.Identity;

namespace ArtWorkPromotion.API.Models
{
	public class AppUser : IdentityUser<Guid>
	{
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }

        public virtual ICollection<Art> Arts { get; set; }
    }
}

