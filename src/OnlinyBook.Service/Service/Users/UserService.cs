using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.Service.Intefaces.Users;
using OnlinyBook.Service.ViewModels.Accounts;

namespace OnlinyBook.Service.Service.Users
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;
		public UserService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<AccountBaseViewModel> GetAsync(long id)
		{
			var temp = await unitOfWork.Users.FindByIdAsync(id);
			var user = new AccountBaseViewModel
			{
				Id = id,
				LastName = temp.LastName,
				FirstName = temp.FirstName,
				Email = temp.Email,
				ImagePath = temp.ImagePath
			};
			return user;
		}
	}
}
