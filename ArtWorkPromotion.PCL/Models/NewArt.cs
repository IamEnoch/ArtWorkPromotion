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
        public NewArt(string name, string description, Guid artistId, string location, double price, Category category)
        {
            Name = name;
            Description = description;
            ArtistId = artistId;
            Location = location;
            Price = price;
            Category = category;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ArtistId { get; set; }

        public string Location { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }
    }
}
