using OnlinyBook.Domain.Entities.Products;

namespace OnlinyBook.DataAccess.Interfaces.Products
{
	public interface IProductCommentRepository : IRepository<ProductComment>
	{
		IQueryable<ProductComment> GetAll(long productId);
	}
}
