using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEventDetailService : IGenericService<EventDetail>
    {
       
        List<EventDetail> TGetGenreById(int id);    
        public List<EventDetail> ListEventDetail();
        List<EventDetail> GetCamp();
        List<EventDetail> GetEvent();   
        List<EventDetail> SearchActivities(string searchTerm);
        
    }
}
