using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.ViewModels.Contacts
{
	public class ContactViewModel
	{
		[Display(Name = "Введите Имя")]
		[Required(ErrorMessage = "Вам нужно ввести имя")]
		public string Name { get; set; }

		[Display(Name = "Введите Фамилию")]
		[Required(ErrorMessage = "Вам нужно ввести Фамилию")]
		public string Surname { get; set; }

		[Display(Name = "Введите возраст")]
		[Required(ErrorMessage = "Вам нужно ввести возраст")]
		public int Age { get; set; }

		[Display(Name = "Введите почту")]
		[Required(ErrorMessage = "Вам нужно ввести почту")]
		public string Email { get; set; }

		[Display(Name = "Введите Сообщение")]
		[StringLength(30, ErrorMessage = "Текст менее 30 символов")]
		[Required(ErrorMessage = "Вам нужно ввести сообщение")]
		public string Message { get; set; }

	}
}
