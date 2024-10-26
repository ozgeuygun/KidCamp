using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FavoriteActivity
    {
        [Key]
        public int FavoriteActivityID { get; set; }
        public int EventDetailID { get; set; }
        public EventDetail EventDetail { get; set; }


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
