using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Employees;
using OnlinyBook.Domain.Entities.Employees;

namespace OnlinyBook.DataAccess.Repositories.Employees
{
	public class OperatorRepository : GenericRepository<Operator>,
	IOperatorRepository
	{
		public OperatorRepository(AppDbContext context) : base(context)
		{
		}
	}
}
