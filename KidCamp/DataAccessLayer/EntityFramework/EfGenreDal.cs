using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGenreDal : GenericRepository<Genre>, IGenreDal
    {
        public List<Genre> ListGenres()
        {
            using (var context = new Context())
            {
                return context.Genres.ToList();
               
            }
        }
    }
}
