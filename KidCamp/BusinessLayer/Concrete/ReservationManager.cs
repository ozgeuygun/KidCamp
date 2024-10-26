using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager:IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetAllReservations(int id)
        {
            return _reservationDal.GetAllReservations(id);
        }

        public List<Reservation> GetAssignedEventNamesForInstructor(int id)
        {
            return _reservationDal.GetAssignedEventNamesForInstructor(id);
        }
      
        public List<Reservation> GetReservationsByEventDetailIdAsync(int id)
        {
            return _reservationDal.GetReservationsByEventDetailIdAsync(id);
        }

        public List<Reservation> GetUserReservationsByEvent()
        {
            return _reservationDal.GetUserReservationsByEvent();
        }

        public void TAdd(Reservation t)
        {
           _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetByID(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
