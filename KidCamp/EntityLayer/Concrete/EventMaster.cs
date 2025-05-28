using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EventMaster
    {
        [Key]
        public int EventMasterID { get; set; }
	public string EventName { get; set; }
        public bool Status { get; set; }
        public List<EventDetail> EventDetails { get; set; }
    }
}
