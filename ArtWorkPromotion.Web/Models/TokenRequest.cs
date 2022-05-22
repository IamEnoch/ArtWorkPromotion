using System.ComponentModel.DataAnnotations;

namespace ArtWorkPromotion.Web.Model;
public class TokenRequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
