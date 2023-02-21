using OnlinyBook.Domain.Common;
using OnlinyBook.Domain.Entities.Categories;

namespace OnlinyBook.Domain.Entities.Products
{
	public class Product : Auditable
	{
		public string Name { get; set; } = String.Empty;

		public double Price { get; set; }

		public string Description { get; set; } = String.Empty;

		public string ImagePath { get; set; } = String.Empty;

		public long CategoryId { get; set; }
		public string ProductPath { get; set; } = String.Empty;

		public virtual Category Category { get; set; } = default!;
	}
}
