using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FacilityManager:IFacilityService
    {
        IFacilityDal _facilityDal;

        public FacilityManager(IFacilityDal facilityDal)
        {
            _facilityDal = facilityDal;
        }

        public void TAdd(Facility t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Facility t)
        {
            throw new NotImplementedException();
        }

        public Facility TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Facility> TGetList()
        {
            return _facilityDal.GetList();
        }

        public void TUpdate(Facility t)
        {
            throw new NotImplementedException();
        }
    }
}
