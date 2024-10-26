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
    public class GenreManager:IGenreService
    {
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public List<Genre> TGetGenreById(int id)
        {
            return _genreDal.GetListByFilter(x => x.GenreID == id);
        }

        public void TAdd(Genre t)
        {
            _genreDal.Insert(t);
        }

        public void TDelete(Genre t)
        {
            _genreDal.Delete(t);
        }

        public Genre TGetByID(int id)
        {
            return _genreDal.GetByID(id);
        }

        public List<Genre> TGetList()
        {
            return _genreDal.GetList();
        }

        public void TUpdate(Genre t)
        {
            _genreDal.Update(t);
        }
       
    }
}
