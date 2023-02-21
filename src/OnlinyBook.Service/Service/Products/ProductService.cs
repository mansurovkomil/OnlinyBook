using Microsoft.EntityFrameworkCore;
using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.Service.Common.Exceptions;
using OnlinyBook.Service.Common.Helpers;
using OnlinyBook.Service.Common.Unils;
using OnlinyBook.Service.Intefaces.Products;
using OnlinyBook.Service.ViewModels.Products;

namespace OnlinyBook.Service.Service.Products
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _repository;
		public ProductService(IUnitOfWork unitOfWork)
		{
			this._repository = unitOfWork;
		}
		public async Task<PagedList<ProductBaseViewModel>> GetAllAsync(PaginationParams @params)
		{
			var query = from product in _repository.Products.GetAll()
						let discountPrice = _repository.ProductDiscounts.GetAll().Where(discount =>
							discount.StartDate < TimeHelper.GetCurrentServerTime()
							&& discount.EndDate > TimeHelper.GetCurrentServerTime()
							&& discount.ProductId == product.Id).Sum(x => x.Price)
						orderby product.CreatedAt descending
						select new ProductBaseViewModel()
						{
							Id = (int)product.Id,
							Name = product.Name,
							Description = product.Description,
							Price = product.Price,
							ImagePath = product.ImagePath,
							ProductsPath = product.ProductPath
						};
			return await PagedList<ProductBaseViewModel>.ToPagedListAsync(query, @params);
		}
		public async Task<ProductViewModel> GetAsync(int productsId)
		{
			var product = await _repository.Products.GetAll().FirstOrDefaultAsync(product => product.Id == productsId);
			if (product is null) throw new NotFoundException("Продукт", "Продукт с таким Id не найдено!");

			double discount = _repository.ProductDiscounts.GetAll().Where(discount =>
							discount.StartDate < TimeHelper.GetCurrentServerTime()
							&& discount.EndDate > TimeHelper.GetCurrentServerTime()
							&& discount.ProductId == product.Id).Sum(x => x.Price);

			return new ProductViewModel()
			{
				Id = (int)product.Id,
				Name = product.Name,
				ImagePath = product.ImagePath,
				Price = product.Price,
				Category = product.Category,
				Description = product.Description,
				ProductsPath = product.ProductPath
            };
		}
	}
}
