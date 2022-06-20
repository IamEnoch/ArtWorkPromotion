using System;
namespace ArtWorkPromotion.PCL.Models
{
    public class Artist
    {
        public Artist()
        {
        }

        public Artist(string name, string email, string phoneNumber, Guid id, string brand, string description, string location, string address, string artistImageUrl)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Id = id;
            Brand = brand;
            Description = description;
            Location = location;
            Address = address;
            ArtistImageUrl = artistImageUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string ArtistImageUrl { get; set; }

        /*public string FullName
        {
            get => $"{FirstName} {LastName}";
            set => fullName = value;
        }*/
    }
}

