using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Products;
using OnlinyBook.Domain.Entities.Products;

namespace OnlinyBook.DataAccess.Repositories.Products
{
	public class ProductCommentRepository : GenericRepository<ProductComment>, IProductCommentRepository
	{
		public ProductCommentRepository(AppDbContext context) : base(context)
		{
		}

		public IQueryable<ProductComment> GetAll(long productId)
			=> _dbcontext.ProductComments.Where(productComment => productComment.ProductId == productId);
	}
}
