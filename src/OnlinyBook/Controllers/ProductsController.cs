using Microsoft.AspNetCore.Mvc;
using OnlinyBook.Service.Common.Helpers;
using OnlinyBook.Service.Common.Unils;
using OnlinyBook.Service.Dtos.Orders;
using OnlinyBook.Service.Intefaces.Orders;
using OnlinyBook.Service.Intefaces.Products;

namespace OnlinyBook.Controllers
{
	[Route("products")]
	public class ProductsController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IProductService _productService;
		private readonly int _pageSize = 2;

		public ProductsController(IProductService productService, IOrderService orderService)
		{
			this._productService = productService;
			this._orderService = orderService;
		}
		public async Task<IActionResult> Index(int page = 1)
		{
			var products = await _productService.GetAllAsync(new PaginationParams(page, _pageSize));
			return View("Index", products);
		}
		[HttpGet("get")]
		public async Task<ViewResult> GetAsync(int productId)
		{
			var product = await _productService.GetAsync(productId);
			var dto = new OrderCreateDto()
			{
				UserId = HttpContextHelper.UserId,
				ProductId = productId,
				Description = product.Description,
				ImagePath = product.ImagePath,
				Name = product.Name,
				Price = product.Price,
			};

			if (product is not null)
			{
				await _orderService.CreateAsync(dto);

			}
			return View(product);
		}

		[HttpGet("down")]
        public FileResult DownloadFile(string fileName)
        {
			//Build the File Path.
			string path = "wwwroot/files/" + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
