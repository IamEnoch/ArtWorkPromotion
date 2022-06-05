using System.ComponentModel.DataAnnotations.Schema;

namespace ArtWorkPromotion.API.Models
{
    public class Social
    {
        public Social(string? whatsApp, string? facebook, string? instagram, string? pintrest)
        {
            WhatsApp = whatsApp;
            Facebook = facebook;
            Instagram = instagram;
            Pintrest = pintrest;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? WhatsApp { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }        
        public string? Pintrest { get; set; }


        [ForeignKey(nameof(AppUser))]
        public Guid AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
