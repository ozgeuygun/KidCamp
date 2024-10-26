using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Collaborate
    {
        [Key]
        public int CollaborateID { get; set; }
        public string Detail { get; set; }
    }
}
