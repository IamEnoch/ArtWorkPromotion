using System;
using ArtWorkPromotion.PCL.Helpers;

namespace ArtWorkPromotion.PCL.Models
{
	public class ArtWork
	{
        public ArtWork()
        {

        }

        public ArtWork(Guid id, string name, string description, 
            Guid artistId, double price, Category category, string ?artImageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            ArtistId = artistId;
            Price = price;
            Category = category;
            ArtImageUrl = artImageUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ArtistId { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public string ArtImageUrl { get; set; }

    }
}

