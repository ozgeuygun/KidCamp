using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EventDetail
    {
        [Key]
        public int EventDetailID { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double Price { get; set; }
        public string EventImage { get; set; }
		public string Description { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public string Participation { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

			
		public int GenreID { get; set; }
        public Genre Genre { get; set; }
    
        public List<Reservation> Reservations{ get; set; }
      
        public int EventMasterID { get; set; }
        public EventMaster EventMaster { get; set; }

        public List<FavoriteActivity> FavoriteActivities { get; set; }

        public List<Testimonial> Testimonials { get; set; }
    }
}
