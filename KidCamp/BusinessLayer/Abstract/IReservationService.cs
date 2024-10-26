using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
     
        List<Reservation> GetAssignedEventNamesForInstructor(int id);
        List<Reservation> GetReservationsByEventDetailIdAsync(int id);     
        List<Reservation> GetAllReservations(int id);
        List<Reservation> GetUserReservationsByEvent();
    }
}
