using Microsoft.EntityFrameworkCore;
using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.Domain.Common;
using System.Linq.Expressions;

namespace OnlinyBook.DataAccess.Repositories
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		protected AppDbContext _dbcontext;
		protected DbSet<T> _dbSet;
		public BaseRepository(AppDbContext context)
		{
			_dbcontext = context;
			_dbSet = context.Set<T>();
		}

		public virtual void Add(T entity) => _dbSet.Add(entity);

		public virtual void Delete(long id)
		{
			var entity = _dbSet.Find(id);
			if (entity is not null)
				_dbSet.Remove(entity);
		}

		public virtual async Task<T?> FindByIdAsync(long id)
		{
			return await _dbSet.FindAsync(id);
		}

		public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
		{
			return await _dbSet.FirstOrDefaultAsync(expression);
		}

		public virtual void Update(long id, T entity)
		{
			entity.Id = id;
			_dbSet.Update(entity);
		}
	}

}
