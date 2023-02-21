using OnlinyBook.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.Dtos.Accounts
{
	public class UserResetPasswordDto
	{
		[Required(ErrorMessage = "Электронная почта обязательна!"), EmailAttribute]
		public string Email { get; set; } = string.Empty;

		[Required]
		public int Code { get; set; }

		[Required, StrongPassword]
		public string Password { get; set; } = string.Empty;
	}
}
