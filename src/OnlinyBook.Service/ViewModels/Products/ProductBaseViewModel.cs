namespace OnlinyBook.Service.ViewModels.Products
{
	public class ProductBaseViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty;
		public string ImagePath { get; set; } = String.Empty;
		public double Price { get; set; }
		public string ProductsPath { get; set; } = String.Empty;
		public string Description { get; set; } = String.Empty;
	}
}
