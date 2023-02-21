using OnlinyBook.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.Dtos.Accounts
{
	public class AccountLoginDto
	{
		[Required(ErrorMessage = "Введите электронную почту")]
		[EmailAddress(ErrorMessage = "Электронная почта введена неправильно")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Введите пароль")]
		[StrongPassword]
		public string Password { get; set; } = string.Empty;
	}
}
