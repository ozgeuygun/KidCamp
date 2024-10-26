using System.ComponentModel.DataAnnotations;

namespace KidCamp.Areas.Member.Models
{
	public class MemberEditViewModel
	{
        public string name { get; set; }
        public string surname { get; set; }
        public string mail { get; set; }
        public string  password { get; set; }     
        public string confirmpassword { get; set; }
        public int childage { get; set; }

    }
}
