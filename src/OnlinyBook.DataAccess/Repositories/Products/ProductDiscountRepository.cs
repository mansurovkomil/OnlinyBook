using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Products;
using OnlinyBook.Domain.Entities.Products;

namespace OnlinyBook.DataAccess.Repositories.Products
{
	public class ProductDiscountRepository : GenericRepository<ProductDiscount>,
	IProductDiscountRepository
	{
		public ProductDiscountRepository(AppDbContext context) : base(context)
		{
		}
	}
}
