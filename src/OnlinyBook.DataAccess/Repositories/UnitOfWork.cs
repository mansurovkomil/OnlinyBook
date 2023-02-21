using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.DataAccess.Interfaces.Categories;
using OnlinyBook.DataAccess.Interfaces.Employees;
using OnlinyBook.DataAccess.Interfaces.Orders;
using OnlinyBook.DataAccess.Interfaces.Products;
using OnlinyBook.DataAccess.Repositories.Categories;
using OnlinyBook.DataAccess.Repositories.Employees;
using OnlinyBook.DataAccess.Repositories.Orders;
using OnlinyBook.DataAccess.Repositories.Products;
using OnlinyBook.DataAccess.Repositories.Users;

namespace OnlinyBook.DataAccess.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext dbContext;
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

		public UnitOfWork(AppDbContext appDbContext)
		{
			this.dbContext = appDbContext;
			Categories = new CategoryRepository(appDbContext);

			Administrators = new AdministratorRepository(appDbContext);
			Delivers = new DeliverRepository(appDbContext);
			Operators = new OperatorRepository(appDbContext);

			Orders = new OrderRepository(appDbContext);
			OrderDetails = new OrderDetailRepository(appDbContext);
			OrderComments = new OrderCommentRepository(appDbContext);

			ProductDiscounts = new ProductDiscountRepository(appDbContext);
			ProductComments = new ProductCommentRepository(appDbContext);
			Products = new ProductRepository(appDbContext);

			Users = new UserRepository(appDbContext);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await dbContext.SaveChangesAsync();
		}
	}

}
