using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ActivityInformation
	{
        [Key]    
        public int InformationID { get; set; }
        public string InformationName { get; set; }
        public string InformationMail { get; set; }
        public string InformationDetail { get; set; }
        public string InformationDetail2 { get; set; }
        public string InformationMessage { get; set; }
    }
}
