﻿using System;
using ArtWorkPromotion.PCL.Helpers;

namespace ArtWorkPromotion.PCL.Models
{
	public class ArtWork
	{
        public ArtWork(Guid id, string name, string description, string artistName,
            Guid artistId, string location, double price, Category category, ArtImages artImages)
        {
            Id = id;
            Name = name;
            Description = description;
            ArtistName = artistName;
            ArtistId = artistId;
            Location = location;
            Price = price;
            Category = category;
            ArtImages = artImages;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ArtistName { get; set; }
        public Guid ArtistId { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public ArtImages ArtImages { get; set; }

    }
}
