using Microsoft.EntityFrameworkCore;
using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.Service.Common.Exceptions;
using OnlinyBook.Service.Common.Helpers;
using OnlinyBook.Service.Common.Unils;
using OnlinyBook.Service.Dtos.Orders;
using OnlinyBook.Service.Dtos.Users;
using OnlinyBook.Service.Intefaces.Accounts;
using OnlinyBook.Service.Intefaces.Orders;
using OnlinyBook.Service.ViewModels.Orders;

namespace OnlinyBook.Service.Service.Orders
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IAccountService _accountService;
		public OrderService(IUnitOfWork dbContext, IAccountService accountService)
		{
			this._unitOfWork = dbContext;
			this._accountService = accountService;
		}
		public async Task<bool> CreateAsync(OrderCreateDto createDto)
		{
			var order = createDto;

			var temp = await _unitOfWork.Users.FindByIdAsync(HttpContextHelper.UserId);

			var result = (from product in _unitOfWork.Orders.GetAll()
						  where product.UserId == order.UserId &&
						  product.ProductId == order.ProductId
						  select product).FirstOrDefault();

			if (result is not null) { return false; }

			var res = new UserUpdateDto()
			{
				FirstName = temp.FirstName,
				LastName = temp.LastName,
				Email = temp.Email,
				ImagePath = temp.ImagePath,
				PhoneNumber = temp.PhoneNumber,
				Money = order.Price
			};
			_accountService.UpdateAsync(HttpContextHelper.UserId, res);

			_unitOfWork.Orders.Add(order);
			var dbResult = await _unitOfWork.SaveChangesAsync();
			return dbResult > 0;
		}


		public async Task<PagedList<OrderBaseViewModel>> GetAllAsync(PaginationParams @params)
		{
			var query = from product in _unitOfWork.Orders.GetAll()
						let discountPrice = _unitOfWork.OrderDetails.GetAll().Where(discount =>
							discount.StartDate < TimeHelper.GetCurrentServerTime()
							&& discount.EndDate > TimeHelper.GetCurrentServerTime()
							&& discount.ProductId == product.Id).Sum(x => x.Price)
						orderby product.CreatedAt descending
						select new OrderBaseViewModel()
						{
							Id = (int)product.Id,
							UserId = product.UserId,
							Name = product.Name,
							Description = product.Description,
							Price = product.Price,
							ImagePath = product.ImagePath
						};

			var query1 = from product in query.Where(discount => discount.UserId == HttpContextHelper.UserId)
						 select new OrderBaseViewModel()
						 {
							 Id = (int)product.Id,
							 Name = product.Name,
							 Description = product.Description,
							 Price = product.Price,
							 ImagePath = product.ImagePath
						 };

			return await PagedList<OrderBaseViewModel>.ToPagedListAsync(query1, @params);
		}


		public async Task<OrderBaseViewModel> GetAsync(long orderId)
		{
			var product = await _unitOfWork.Orders.GetAll().FirstOrDefaultAsync(product => product.Id == orderId);
			if (product is null) throw new NotFoundException("Продукт", "Продукт с таким Id не найдено!");

			double discount = _unitOfWork.OrderDetails.GetAll().Where(discount =>
							discount.StartDate < TimeHelper.GetCurrentServerTime()
							&& discount.EndDate > TimeHelper.GetCurrentServerTime()
							&& discount.ProductId == product.Id).Sum(x => x.Price);

			return new OrderBaseViewModel()
			{
				Id = (int)product.Id,
				Name = product.Name,
				ImagePath = product.ImagePath,
				Price = product.Price,
				Description = product.Description
			};
		}
	}
}
