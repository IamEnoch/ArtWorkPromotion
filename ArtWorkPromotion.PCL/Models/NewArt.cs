using ArtWorkPromotion.PCL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtWorkPromotion.PCL.Models
{
    public class NewArt
    {
        public NewArt(string name, string description, Guid artistId, double price, Category category, string artImageUrl)
        {
            Name = name;
            Description = description;
            ArtistId = artistId;
            Price = price;
            Category = category;
            ArtImageUrl = artImageUrl;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ArtistId { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }

        public string ?ArtImageUrl { get; set; }
    }
}
