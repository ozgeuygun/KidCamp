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
    public class EventDetailManager:IEventDetailService
    {
        IEventDetailDal _eventdetailDal;

        public EventDetailManager(IEventDetailDal eventdetailDal)
        {
            _eventdetailDal = eventdetailDal;
        }

        public void TAdd(EventDetail t)
        {
            _eventdetailDal.Insert(t);
        }

        public void TDelete(EventDetail t)
        {
            _eventdetailDal.Delete(t);
        }

        public EventDetail TGetByID(int id)
        {
            return _eventdetailDal.GetByID(id);
        }

        public List<EventDetail> TGetList()
        {
            return _eventdetailDal.GetList().Where(x => x.Status == true).ToList();
        }

        public void TUpdate(EventDetail t)
        {
            _eventdetailDal.Update(t);
        }
        public List<EventDetail> TGetGenreById(int id)
        {
            return _eventdetailDal.GetListByFilter(x => x.GenreID == id);
        }

        public List<EventDetail> ListEventDetail()
        {
            return _eventdetailDal.ListEventDetail();
        }

		public List<EventDetail> GetCamp()
		{
            return _eventdetailDal.GetCamp();

		}
		public List<EventDetail> GetEvent()
		{
			return _eventdetailDal.GetEvent();

		}

        public List<EventDetail> SearchActivities(string searchTerm)
        {
            return _eventdetailDal.SearchActivities(searchTerm);
        }

       
    }
}
