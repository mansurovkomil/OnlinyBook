using OnlinyBook.Domain.Common;
using System.Linq.Expressions;

namespace OnlinyBook.DataAccess.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		public Task<T?> FindByIdAsync(long id);

		public Task<T?> GetAsync(Expression<Func<T, bool>> expression);

		public void Add(T entity);

		public void Delete(long id);

		public void Update(long id, T entity);
	}
}
