using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFavoriteActivityService : IGenericService<FavoriteActivity>
    {
        List<FavoriteActivity> GetAllFavorities(int id);
    }
}
