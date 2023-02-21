using Microsoft.EntityFrameworkCore;
using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.Domain.Entities.Categories;
using OnlinyBook.Service.Common.Unils;
using OnlinyBook.Service.Intefaces.Categories;

namespace OnlinyBook.Service.Service.Categories
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _repository;
		public CategoryService(IUnitOfWork unitOfWork)
		{
			this._repository = unitOfWork;
		}
		public async Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
		{
			return await _repository.Categories.GetAll()
				.Skip((@params.PageNumber - 1) * @params.PageSize)
				.Take(@params.PageSize).ToListAsync();
		}
	}
}
