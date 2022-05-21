using System;
using System.ComponentModel.DataAnnotations.Schema;
using ArtWorkPromotion.PCL.Helpers;

namespace ArtWorkPromotion.API.Models
{
	public class Art
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        [ForeignKey(nameof(AppUser))]
        public Guid AppUserId { get; set; }
        public string StoragePath { get; set; }
        public string Location { get; set; }


        public virtual AppUser AppUser { get; set; }
    }
}

