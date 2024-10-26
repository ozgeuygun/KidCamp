using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Facility
    {
        [Key]
        public int FacilityID { get; set; }
        public string FacilityTitle { get; set; }
        public string FacilityDescription { get; set; }
        public string FacilityImage { get; set; }
        public string FacilityImage2 { get; set; }
        public string FacilityImage3 { get; set; }
        public string FacilityImage4 { get; set; }
        public string FacilityImage5 { get; set; }
        public string FacilityImage6 { get; set; }
    }
}
