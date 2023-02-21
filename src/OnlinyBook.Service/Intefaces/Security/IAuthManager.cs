using OnlinyBook.Domain.Entities.Users;

namespace OnlinyBook.Service.Intefaces.Security
{
	public interface IAuthManager
	{
		public string GenerateToken(User user);
	}
}
