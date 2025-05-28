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
	public class ActivityInformationManager:IActivityInformationService
	{
		IActivityInformationDal _activityInformationDal;

		public ActivityInformationManager(IActivityInformationDal activityInformationDal)
		{
			_activityInformationDal = activityInformationDal;
		}

		public void TAdd(ActivityInformation t)
		{
			_activityInformationDal.Insert(t);
		}

		public void TDelete(ActivityInformation t)
		{
			_activityInformationDal.Delete(t);
		}

		public ActivityInformation TGetByID(int id)
		{
                        return _activityInformationDal.GetByID(id);
                }

		public List<ActivityInformation> TGetList()
		{
			return _activityInformationDal.GetList();
		}

		public void TUpdate(ActivityInformation t)
		{
			throw new NotImplementedException();
		}
	}
}
