using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Employees;
using OnlinyBook.Domain.Entities.Employees;

namespace OnlinyBook.DataAccess.Repositories.Employees
{
	public class DeliverRepository : GenericRepository<Deliver>,
	IDeliverRepository
	{
		public DeliverRepository(AppDbContext context) : base(context)
		{
		}
	}
}
