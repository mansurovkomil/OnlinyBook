using OnlinyBook.Domain.Entities.Orders;

namespace OnlinyBook.DataAccess.Interfaces.Orders
{
	public interface IOrderCommentRepository : IRepository<OrderComment>
	{
		IQueryable<OrderComment> GetAll(long orderId);
	}
}
