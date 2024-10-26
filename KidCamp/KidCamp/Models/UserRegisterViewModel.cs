using System.ComponentModel.DataAnnotations;

namespace KidCamp.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen adınızı giriniz")]
		public string RegisterName { get; set; }


		[Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
		public string RegisterSurname { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen mailinizi giriniz")]
		public string RegisterMail { get; set; }

		[Required(ErrorMessage = "Lütfen çocuğunuzun adını giriniz")]
		public string RegisterChildName { get; set; }

		[Required(ErrorMessage = "Lütfen çocuğunuzun yaşını giriniz")]
		[Range(1, 12, ErrorMessage = "Çocuk yaşı 1 ile 12 arasında olmalıdır.")]
		public int RegisterChildAge { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
		[Compare("Password", ErrorMessage ="şifreler aynı değil")]
		public string ConfirmPassword { get; set; }
	}
}
