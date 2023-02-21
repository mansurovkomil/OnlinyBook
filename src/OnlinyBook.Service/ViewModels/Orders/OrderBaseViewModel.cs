namespace OnlinyBook.Service.ViewModels.Orders
{
	public class OrderBaseViewModel
	{
		public int Id { get; set; }
		public long UserId { get; set; }
		public string Name { get; set; } = String.Empty;
		public string ImagePath { get; set; } = String.Empty;
		public double Price { get; set; }
		public string Description { get; set; } = String.Empty;
		public long ProductId { get; set; }
		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }
	}
}
