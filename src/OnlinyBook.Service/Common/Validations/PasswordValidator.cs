namespace OnlinyBook.Service.Common.Validations
{
	public class PasswordValidator
	{
		public static (bool IsValid, string Message) IsStrong(string password)
		{
			bool isDigit = password.Any(x => char.IsDigit(x));
			bool isLower = password.Any(x => char.IsLower(x));
			bool isUpper = password.Any(x => char.IsUpper(x));
			if (!isLower)
				return (IsValid: false, Message: "Пароль должен состоять хотя бы из одной строчной буквы!");
			if (!isUpper)
				return (IsValid: false, Message: "Пароль должен состоять хотя бы из одной заглавной буквы!");
			if (!isDigit)
				return (IsValid: false, Message: "Пароль должен состоять хотя бы из одной цифры!");

			return (IsValid: true, Message: "Пароль надежный");
		}
	}
}
