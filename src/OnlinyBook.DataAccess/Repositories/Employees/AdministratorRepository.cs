using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Employees;
using OnlinyBook.Domain.Entities.Employees;

namespace OnlinyBook.DataAccess.Repositories.Employees
{
	public class AdministratorRepository : GenericRepository<Administator>,
	IAdministratorRepository
	{
		public AdministratorRepository(AppDbContext context) : base(context)
		{
		}
	}
}
