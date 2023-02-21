using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Orders;
using OnlinyBook.Domain.Entities.Orders;

namespace OnlinyBook.DataAccess.Repositories.Orders
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(AppDbContext context) : base(context)
		{
		}
	}
}
