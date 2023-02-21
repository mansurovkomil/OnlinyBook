using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.Dtos.Accounts
{
	public class PasswordUpdateDto
	{
		[Required(ErrorMessage = ("Введите старый пароль"))]
		public string OldPassword { get; set; } = default!;

		[Required(ErrorMessage = ("Введите новый пароль"))]
		public string NewPassword { get; set; } = default!;

		[Required(ErrorMessage = ("Введите пароль для подтверждения"))]
		public string VerifyPassword { get; set; } = default!;
	}
}
