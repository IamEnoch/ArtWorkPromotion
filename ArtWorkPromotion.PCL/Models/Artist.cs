using System;
namespace ArtWorkPromotion.PCL.Models
{
    public class Artist
    {
        private string fullName;

        public Artist()
        {
        }

        public Artist(string firstName, string lastName, string email, string phoneNumber, Guid id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Id = id;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
            set => fullName = value;
        }
    }
}

