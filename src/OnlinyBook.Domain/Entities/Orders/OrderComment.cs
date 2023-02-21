using OnlinyBook.Domain.Common;

namespace OnlinyBook.Domain.Entities.Orders
{
	public class OrderComment : Auditable
	{
		public long OrderId { get; set; }
		public virtual Order Order { get; set; } = default!;

		public string Comment { get; set; } = String.Empty;
	}
}
