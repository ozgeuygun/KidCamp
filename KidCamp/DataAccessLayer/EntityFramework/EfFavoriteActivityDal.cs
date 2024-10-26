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
    public class EfFavoriteActivityDal : GenericRepository<FavoriteActivity>, IFavoriteActivityDal
    {
        public List<FavoriteActivity> GetAllFavorities(int id)
        {
            using (var context = new Context())
            {

                return context.FavoriteActivities.Include(x => x.EventDetail).Where(x => x.AppUserId == id).ToList();
            }
        }
    }
}
