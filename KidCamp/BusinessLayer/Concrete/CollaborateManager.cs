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
    public class CollaborateManager:ICollaborateService
    {
        ICollaborateDal _collaborateDal;

        public CollaborateManager(ICollaborateDal collaborateDal)
        {
            _collaborateDal = collaborateDal;
        }

        public void TAdd(Collaborate t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Collaborate t)
        {
            throw new NotImplementedException();
        }

        public Collaborate TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Collaborate> TGetList()
        {
            return _collaborateDal.GetList();
        }

        public void TUpdate(Collaborate t)
        {
            throw new NotImplementedException();
        }
    }
}
