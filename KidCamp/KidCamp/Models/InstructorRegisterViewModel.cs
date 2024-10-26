using System.ComponentModel.DataAnnotations;

namespace KidCamp.Models
{
    public class InstructorRegisterViewModel
    {
        [Required(ErrorMessage = "eğitmenin adını girin")]
        public string RegisterName { get; set; }


        [Required(ErrorMessage = "eğitmenin soyadını girin")]
        public string RegisterSurname { get; set; }

        [Required(ErrorMessage = "eğitmenin kullanıcı adını girin")]
        public string Username { get; set; }

        [Required(ErrorMessage = "eğitmenin mailini girin")]
        public string RegisterMail { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
    }
}
