﻿using OnlinyBook.Domain.Common;
using System.Linq.Expressions;

namespace OnlinyBook.DataAccess.Interfaces
{
	public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
	{
		public IQueryable<T> GetAll();

		public IQueryable<T> Where(Expression<Func<T, bool>> expression);
	}
}