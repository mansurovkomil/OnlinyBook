using OnlinyBook.Domain.Entities.Orders;
using OnlinyBook.Service.Common.Helpers;

namespace OnlinyBook.Service.Dtos.Orders
{
	public class OrderCreateDto
	{
		public long Id { get; set; }
		public long UserId { get; set; }
		public long ProductId { get; set; }
		public string Name { get; set; } = String.Empty;

		public double Price { get; set; }

		public string Description { get; set; } = String.Empty;

		public string ImagePath { get; set; } = String.Empty;

		public static implicit operator Order(OrderCreateDto orderCreateDto)
		{
			return new Order()
			{
				Id = orderCreateDto.Id,
				UserId = orderCreateDto.UserId,
				Name = orderCreateDto.Name,
				Description = orderCreateDto.Description,
				ImagePath = orderCreateDto.ImagePath,
				Price = orderCreateDto.Price,
				ProductId = orderCreateDto.ProductId,
				CreatedAt = TimeHelper.GetCurrentServerTime(),
				UpdatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
