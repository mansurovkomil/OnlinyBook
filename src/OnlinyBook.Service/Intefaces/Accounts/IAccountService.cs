using OnlinyBook.Service.Dtos.Accounts;
using OnlinyBook.Service.Dtos.Users;

namespace OnlinyBook.Service.Intefaces.Accounts
{
	public interface IAccountService
	{
		public Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto);
		public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
		public Task<bool> UpdateAsync(long id, UserUpdateDto entity);

	}
}
