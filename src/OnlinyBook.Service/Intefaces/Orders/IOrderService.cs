using OnlinyBook.Service.Common.Unils;
using OnlinyBook.Service.Dtos.Orders;
using OnlinyBook.Service.ViewModels.Orders;

namespace OnlinyBook.Service.Intefaces.Orders
{
	public interface IOrderService
	{
		public Task<PagedList<OrderBaseViewModel>> GetAllAsync(PaginationParams @params);

		public Task<OrderBaseViewModel> GetAsync(long orderId);

		public Task<bool> CreateAsync(OrderCreateDto createDto);

	}
}
