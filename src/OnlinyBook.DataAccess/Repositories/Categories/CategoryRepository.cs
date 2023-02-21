using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces.Categories;
using OnlinyBook.Domain.Entities.Categories;

namespace OnlinyBook.DataAccess.Repositories.Categories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext context) : base(context)
		{
		}
	}
}
