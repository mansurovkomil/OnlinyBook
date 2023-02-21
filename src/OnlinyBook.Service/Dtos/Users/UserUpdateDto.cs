using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OnlinyBook.Service.Dtos.Users
{
	public class UserUpdateDto
	{
		[Required, MaxLength(30), MinLength(3)]
		public string FirstName { get; set; } = String.Empty;

		[Required, MaxLength(30), MinLength(3)]
		public string LastName { get; set; } = String.Empty;

		public string? ImagePath { get; set; }
		public string Email { get; set; } = String.Empty;

		[Required, MaxLength(30), MinLength(3)]
		public string PhoneNumber { get; set; } = String.Empty;
		public double Money { get; set; }
	}
}
