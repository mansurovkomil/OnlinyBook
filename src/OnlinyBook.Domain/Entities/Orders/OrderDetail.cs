using OnlinyBook.Domain.Common;
using OnlinyBook.Domain.Entities.Products;

namespace OnlinyBook.Domain.Entities.Orders
{
	public class OrderDetail : Auditable
	{
		public long ProductId { get; set; }
		public virtual Product Product { get; set; } = default!;

		public double Price { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Description { get; set; } = String.Empty;

	}
}
