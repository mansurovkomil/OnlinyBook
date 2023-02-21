using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.Domain.Entities.Users;
using OnlinyBook.Domain.Enums;
using OnlinyBook.Service.Common.Exceptions;
using OnlinyBook.Service.Common.Helpers;
using OnlinyBook.Service.Common.Security;
using OnlinyBook.Service.Dtos.Accounts;
using OnlinyBook.Service.Dtos.Users;
using OnlinyBook.Service.Intefaces.Accounts;
using OnlinyBook.Service.Intefaces.Security;

namespace OnlinyBook.Service.Service.Accounts
{
	public class AccountService : IAccountService
	{
		private readonly IUnitOfWork _repository;
		private readonly IAuthManager _authService;
		private readonly AppDbContext _appDbContext;

		public AccountService(IUnitOfWork unitOfWork, IAuthManager authService, AppDbContext appDbContext)
		{
			this._repository = unitOfWork;
			this._authService = authService;
			this._appDbContext = appDbContext;
		}

		public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
		{
			var emailedUser = await _repository.Users.GetAsync(x => x.Email == accountLoginDto.Email);
			if (emailedUser is null) throw new ModelErrorException(nameof(accountLoginDto.Email), "С такой электронной почтой пользователь недоступен!");

			var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, emailedUser.Salt, emailedUser.PasswordHash);
			if (hasherResult)
			{
				string token = _authService.GenerateToken(emailedUser);
				return token;
			}
			else throw new ModelErrorException(nameof(accountLoginDto.Password), "Пароль набран неправильно!");
		}

		public async Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto)
		{
			var emailedUser = await _repository.Users.GetAsync(x => x.Email == accountRegisterDto.Email);
			if (emailedUser is not null) throw new Exception();

			var phonedUser = await _repository.Users.GetAsync(x => x.PhoneNumber == accountRegisterDto.PhoneNumber);
			if (phonedUser is not null) throw new Exception();

			var hasherResult = PasswordHasher.Hash(accountRegisterDto.Password);
			var user = (User)accountRegisterDto;
			user.PasswordHash = hasherResult.passwordHash;
			user.ImagePath = "media/avatars/avatar.jpg";
			user.Money = 300000;
			user.Salt = hasherResult.salt;
			user.UserRole = UserRole.User;

			_repository.Users.Add(user);
			var dbResult = await _repository.SaveChangesAsync();
			return dbResult > 0;
		}

		public async Task<bool> UpdateAsync(long id, UserUpdateDto entity)
		{
			if (id == HttpContextHelper.UserId || HttpContextHelper.UserRole != "User")
			{
				var temp = await _appDbContext.Users.FindAsync(id);

				if (entity.Money == 0)
				{
					temp.UpdatedAt = TimeHelper.GetCurrentServerTime();
					temp.PhoneNumber = string.IsNullOrWhiteSpace(entity.PhoneNumber) ? temp.PhoneNumber : entity.PhoneNumber;
					temp.LastName = string.IsNullOrWhiteSpace(entity.LastName) ? temp.LastName : entity.LastName;
					temp.FirstName = string.IsNullOrWhiteSpace(entity.FirstName) ? temp.FirstName : entity.FirstName;
					temp.ImagePath = string.IsNullOrWhiteSpace(entity.ImagePath) ? temp.ImagePath : entity.ImagePath;
				}
				else
				{
					temp.Money = temp.Money - entity.Money;
					temp.UpdatedAt = TimeHelper.GetCurrentServerTime();
				}
				_appDbContext.Users.Update(temp);
				var result = await _appDbContext.SaveChangesAsync();
				return result > 0;
			}
			else throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, "Не допускается");
		}
	}
}

