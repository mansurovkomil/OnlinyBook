using OnlinyBook.Domain.Entities.Users;

namespace OnlinyBook.DataAccess.Interfaces.Users
{
	public interface IUserRepository : IGenericRepository<User>
	{
		public Task<User?> GetByEmailAsync(string email);
	}
}
