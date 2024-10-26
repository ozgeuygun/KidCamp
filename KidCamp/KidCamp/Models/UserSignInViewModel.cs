using System.ComponentModel.DataAnnotations;

namespace KidCamp.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="kullanıcı adını giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "kullanıcı şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
