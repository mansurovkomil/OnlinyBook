
using Microsoft.EntityFrameworkCore;

namespace OnlinyBook.Service.Common.Unils
{
	public class PagedList<T> : List<T>
	{
		public PaginationMetaData MetaData { get; set; } = default;

		public PagedList(List<T> items, int totalAmout, PaginationParams @params)
		{
			this.MetaData = new PaginationMetaData(totalAmout, @params.PageNumber, @params.PageSize);
			AddRange(items);
		}

		public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, PaginationParams @params)
		{
			int totalAmout = source.Count();
			var items = await source.Skip((@params.PageNumber - 1) * @params.PageSize)
									.Take(@params.PageSize)
									.ToListAsync();
			return new PagedList<T>(items, totalAmout, @params);
		}

	}
}
