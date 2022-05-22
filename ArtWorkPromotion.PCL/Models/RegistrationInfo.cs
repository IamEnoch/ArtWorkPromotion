using System;
using System.ComponentModel.DataAnnotations;

namespace ArtWorkPromotion.PCL.Models
{
	public class RegistrationInfo
	{
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }

    }
}

