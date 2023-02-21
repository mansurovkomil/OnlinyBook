using OnlinyBook.Domain.Entities.Categories;

namespace OnlinyBook.Service.ViewModels.Products
{
	public class ProductViewModel : ProductBaseViewModel
	{
		public Category Category { get; set; } = default!;
	}
}
