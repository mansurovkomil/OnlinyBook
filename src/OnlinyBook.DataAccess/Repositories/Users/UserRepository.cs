using Microsoft.EntityFrameworkCore;
using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Users;
using OnlinyBook.Domain.Entities.Users;

namespace OnlinyBook.DataAccess.Repositories.Users
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<User?> GetByEmailAsync(string email)
			=> await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == email);
	}
}
