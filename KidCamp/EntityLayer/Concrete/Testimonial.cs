using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }

        [Required(ErrorMessage = "Lütfen  giriniz")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Lütfen  giriniz")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Lütfen  giriniz")]
        public string ClientDetail { get; set; }

        public string TestimonialImage { get; set; }
        public bool Status { get; set; }


        [Required(ErrorMessage = "Lütfen  giriniz")]
        public int EventDetailID { get; set; }
        public EventDetail EventDetail { get; set; }


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
