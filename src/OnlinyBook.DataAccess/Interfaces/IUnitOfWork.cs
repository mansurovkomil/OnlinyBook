using OnlinyBook.DataAccess.Interfaces.Categories;
using OnlinyBook.DataAccess.Interfaces.Employees;
using OnlinyBook.DataAccess.Interfaces.Orders;
using OnlinyBook.DataAccess.Interfaces.Products;

namespace OnlinyBook.DataAccess.Interfaces
{
	public interface IUnitOfWork
	{
		public ICategoryRepository Categories { get; }

		public IAdministratorRepository Administrators { get; }
		public IDeliverRepository Delivers { get; }
		public IOperatorRepository Operators { get; }

		public IOrderCommentRepository OrderComments { get; }
		public IOrderDetailRepository OrderDetails { get; }
		public IOrderRepository Orders { get; }

		public IProductRepository Products { get; }
		public IProductCommentRepository ProductComments { get; }
		public IProductDiscountRepository ProductDiscounts { get; }

		public Interfaces.Users.IUserRepository Users { get; }

		public Task<int> SaveChangesAsync();
	}
}
