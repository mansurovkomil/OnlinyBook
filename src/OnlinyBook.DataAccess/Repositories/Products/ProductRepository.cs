using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Products;
using OnlinyBook.Domain.Entities.Products;

namespace OnlinyBook.DataAccess.Repositories.Products
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context)
		{
		}
	}
}
