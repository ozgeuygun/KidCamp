using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEventDetailDal:IGenericDal<EventDetail>
    {

        public List<EventDetail> ListEventDetail();     
        List<EventDetail> GetCamp();
		List<EventDetail> GetEvent();     
        List<EventDetail> SearchActivities(string searchTerm);
        
    }
   
}
