using OnlinyBook.Service.Common.Unils;
using OnlinyBook.Service.ViewModels.Products;

namespace OnlinyBook.Service.Intefaces.Products
{
	public interface IProductService
	{
		public Task<PagedList<ProductBaseViewModel>> GetAllAsync(PaginationParams @params);

		public Task<ProductViewModel> GetAsync(int productsId);
	}
}
