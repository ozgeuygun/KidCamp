﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetAssignedEventNamesForInstructor(int id);
        List<Reservation> GetReservationsByEventDetailIdAsync(int id);
        List<Reservation> GetAllReservations(int id);
        List<Reservation> GetUserReservationsByEvent();
    }
}
