using OnlinyBook.Service.Common.Validations;
using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class StrongPasswordAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value is null) return new ValidationResult("Пароль не может быть нулевым!");
			else
			{
				string password = value.ToString()!;
				if (password.Length < 8)
					return new ValidationResult("Пароль должен состоять не менее чем из 8 символов!");
				if (password.Length > 50)
					return new ValidationResult("Пароль должен содержать менее 50 символов!");

				var result = PasswordValidator.IsStrong(password);

				if (result.IsValid is false) return new ValidationResult(result.Message);

				return ValidationResult.Success;
			}
		}
	}
}
