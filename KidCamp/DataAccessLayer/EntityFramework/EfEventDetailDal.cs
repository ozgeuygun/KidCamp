using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfEventDetailDal : GenericRepository<EventDetail>, IEventDetailDal
    {
  

        public List<EventDetail> ListEventDetail()
        {
            using (var context = new Context())
            {
                return context.EventDetails.Include(x => x.EventMaster).ToList();
            }
        }

        public List<EventDetail> GetCamp()
        {
            using (var context = new Context())
            {

                return context.EventDetails.Include(x => x.Genre).Where(x => x.GenreID == 1 && x.Status==true).ToList();
            }
        }

        public List<EventDetail> GetEvent()
        {
            using (var context = new Context())
            {

                return context.EventDetails.Include(x => x.Genre).Where(x => x.GenreID == 2 && x.Status == true).ToList();
            }
        }

        public List<EventDetail> SearchActivities(string searchTerm)
        {
            using (var context = new Context())
            {

                if (string.IsNullOrWhiteSpace(searchTerm))
                    return context.EventDetails.ToList();

                return context.EventDetails.Where(e => e.EventName.Contains(searchTerm) || e.Location.Contains(searchTerm)).ToList(); 
            }
        }

     
    }
        

    }

