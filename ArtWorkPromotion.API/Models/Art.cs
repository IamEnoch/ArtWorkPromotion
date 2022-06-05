using System;
using System.ComponentModel.DataAnnotations.Schema;
using ArtWorkPromotion.PCL.Helpers;

namespace ArtWorkPromotion.API.Models
{
	public class Art
	{
        public Art()
        {

        }

        public Art(string name, string description, double price,
            Category category, Guid appUserId, string storagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            AppUserId = appUserId;
            StoragePath = storagePath;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        [ForeignKey(nameof(AppUser))]
        public Guid AppUserId { get; set; }
        public string StoragePath { get; set; }


        public virtual AppUser AppUser { get; set; }
    }
}

