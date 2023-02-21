using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Orders;
using OnlinyBook.Domain.Entities.Orders;

namespace OnlinyBook.DataAccess.Repositories.Orders
{
	public class OrderCommentRepository : GenericRepository<OrderComment>, IOrderCommentRepository
	{
		public OrderCommentRepository(AppDbContext context) : base(context)
		{
		}

		public IQueryable<OrderComment> GetAll(long orderId)
		{
			throw new NotImplementedException();
		}
	}
}
