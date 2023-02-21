using Microsoft.AspNetCore.Mvc;
using OnlinyBook.Service.Common.Unils;
using OnlinyBook.Service.Intefaces.Orders;

namespace OnlinyBook.Controllers
{
	[Route("orders")]
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly int _pageSize = 30;

		public OrderController(IOrderService orderService)
		{
			this._orderService = orderService;
		}
		public async Task<IActionResult> Index(int page = 1)
		{
			var products = await _orderService.GetAllAsync(new PaginationParams(page, _pageSize));
			return View("Index", products);
		}

	}
}
