using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Orders;
using OnlinyBook.Domain.Entities.Orders;

namespace OnlinyBook.DataAccess.Repositories.Orders
{
	public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
	{
		public OrderDetailRepository(AppDbContext context) : base(context)
		{
		}

		public IQueryable<OrderDetail> GetAll(long orderId)
			=> _dbSet.Where(x => x.Id == orderId);
	}
}
