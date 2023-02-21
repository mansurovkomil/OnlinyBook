namespace OnlinyBook.Service.Intefaces.Common
{
	public interface IIdentityService
	{
		public long? Id { get; }

		public string FirstName { get; }

		public string LastName { get; }

		public string Email { get; }

		public string ImagePath { get; }
		public double Money { get; }

	}

}
