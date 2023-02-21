using OnlinyBook.Service.ViewModels.Accounts;

namespace OnlinyBook.Service.Intefaces.Users
{
	public interface IUserService
	{
		public Task<AccountBaseViewModel> GetAsync(long id);
	}
}
