using System;
using System.ComponentModel.DataAnnotations;

namespace ArtWorkPromotion.PCL.Models
{
	public class RegistrationInfo
	{
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }


        [Required]
        public string Password { get; set; }

    }
}

