using System;
using System.ComponentModel.DataAnnotations;

namespace ArtWorkPromotion.PCL.Models
{
	public class LoginInfo
	{
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }
    }
}

