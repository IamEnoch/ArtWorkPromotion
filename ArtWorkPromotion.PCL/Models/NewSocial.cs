using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtWorkPromotion.PCL.Models
{
    public  class NewSocial
    {
        public NewSocial(string? whatsApp, string? facebook, string? instagram, string? pintrest, Guid userId)
        {
            WhatsApp = whatsApp;
            Facebook = facebook;
            Instagram = instagram;
            Pintrest = pintrest;
            UserId = userId;
        }
        public Guid Id { get; set; }
        public string? WhatsApp { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Pintrest { get; set; }
        public Guid UserId { get; set; }
    }
}
