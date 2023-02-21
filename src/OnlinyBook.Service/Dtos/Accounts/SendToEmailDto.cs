using OnlinyBook.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.Dtos.Accounts
{
	public class SendToEmailDto
	{
		[Required(ErrorMessage = "Электронная почта обязательна!"), EmailAttribute]
		public string Email { get; set; } = string.Empty;
	}
}
