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
    public class FavoriteActivityManager:IFavoriteActivityService
    {
        IFavoriteActivityDal _favoriteActivityDal;

        public FavoriteActivityManager(IFavoriteActivityDal favoriteActivityDal)
        {
            _favoriteActivityDal = favoriteActivityDal;
        }

        public List<FavoriteActivity> GetAllFavorities(int id)
        {
            return _favoriteActivityDal.GetAllFavorities(id);
        }

        public void TAdd(FavoriteActivity t)
        {
            _favoriteActivityDal.Insert(t);
        }

        public void TDelete(FavoriteActivity t)
        {
            _favoriteActivityDal.Delete(t);
        }

        public FavoriteActivity TGetByID(int id)
        {
            return _favoriteActivityDal.GetByID(id);
        }

        public List<FavoriteActivity> TGetList()
        {
           return _favoriteActivityDal.GetList();
        }

        public void TUpdate(FavoriteActivity t)
        {
            _favoriteActivityDal.Update(t);
        }
    }
}
