using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetAllReservations(int id)
        {
            using (var context = new Context())
            {

                return context.Reservations.Include(x => x.EventDetail).Where(x=>x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetAssignedEventNamesForInstructor(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.EventDetail).Where(x =>x.AppUserId == id).ToList();
               
            }
        }
				

        public List<Reservation> GetReservationsByEventDetailIdAsync(int id)
        {
            using (var context = new Context())
            {

                return context.Reservations.Include(x => x.AppUser).Where(x => x.EventDetailID == id).ToList();



            }
		}

        public List<Reservation> GetUserReservationsByEvent()
        {
            using (var context = new Context())
            {

                return context.Reservations.Include(x => x.EventDetail).Include(x=>x.AppUser).ToList();



            }
        }

      
    }
}
