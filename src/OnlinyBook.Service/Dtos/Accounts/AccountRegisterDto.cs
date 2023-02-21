using OnlinyBook.Domain.Entities.Users;
using OnlinyBook.Service.Common.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.Dtos.Accounts
{
	public class AccountRegisterDto
	{
		[Required(ErrorMessage = "Введите фамилию")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Введите имя")]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Введите номер телефон")]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required(ErrorMessage = "Введите электронную почту")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Введите пароль")]
		public string Password { get; set; } = string.Empty;

		public double Money { get; set; }

		public static implicit operator User(AccountRegisterDto accountRegisterDto)
		{
			return new User()
			{
				FirstName = accountRegisterDto.FirstName,
				LastName = accountRegisterDto.LastName,
				Email = accountRegisterDto.Email,
				Money = accountRegisterDto.Money,
				EmailConfirmed = false,
				PhoneNumber = accountRegisterDto.PhoneNumber,
				PhoneNumberConfirmed = false,
				CreatedAt = TimeHelper.GetCurrentServerTime(),
				UpdatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
