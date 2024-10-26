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
    public class EventMasterManager:IEventMasterService
    {
        IEventMasterDal _eventMasterDal;

        public EventMasterManager(IEventMasterDal eventMasterDal)
        {
            _eventMasterDal = eventMasterDal;
        }

        public void TAdd(EventMaster t)
        {
            _eventMasterDal.Insert(t);
        }

        public void TDelete(EventMaster t)
        {
            _eventMasterDal.Delete(t);
        }

        public EventMaster TGetByID(int id)
        {
            return _eventMasterDal.GetByID(id);
        }

        public List<EventMaster> TGetList()
        {
            return _eventMasterDal.GetList().Where(x => x.Status == true).ToList();
        }

        public void TUpdate(EventMaster t)
        {
            _eventMasterDal.Update(t);
        }
    }
}
