using OnlinyBook.Domain.Common;

namespace OnlinyBook.Domain.Entities.Orders
{
	public class Order : Auditable
	{
		public long UserId { get; set; }
		public string Name { get; set; } = String.Empty;
		public long ProductId { get; set; }
		public double Price { get; set; }

		public string Description { get; set; } = String.Empty;

		public string ImagePath { get; set; } = String.Empty;
	}
}
