using Microsoft.AspNetCore.Mvc;
using OnlinyBook.Service.Common.Exceptions;
using OnlinyBook.Service.Common.Helpers;
using OnlinyBook.Service.Dtos.Accounts;
using OnlinyBook.Service.Dtos.Users;
using OnlinyBook.Service.Intefaces.Accounts;
using OnlinyBook.Service.Intefaces.Users;

namespace OnlinyBook.Controllers
{
	[Route("account")]
	public class AccountController : Controller
	{
		private readonly IAccountService _service;
		private readonly IUserService _userService;
		public AccountController(IAccountService acccountService, IUserService userService)
		{
			this._service = acccountService;
			this._userService = userService;
		}
		[HttpGet("login")]
		public ViewResult Login()
		{
			return View("Login");
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
		{
			if (ModelState.IsValid)
			{
				try
				{
					string token = await _service.LoginAsync(accountLoginDto);
					HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
					{
						HttpOnly = true,
						SameSite = SameSiteMode.Strict
					});
					return RedirectToAction("Index", "Home", new { area = "" });
				}
				catch (ModelErrorException modelError)
				{
					ModelState.AddModelError(modelError.Property, modelError.Message);
					return Login();
				}
			}
			else return Login();
		}

		[HttpGet("register")]
		public ViewResult Register()
		{
			return View("Register");
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
		{
			if (ModelState.IsValid)
			{
				bool result = await _service.RegisterAsync(accountRegisterDto);
				if (result)
					return RedirectToAction("login", "account", new { area = "" });
				else
					return Register();
			}
			else return Register();
		}

		[HttpGet("logout")]
		public IActionResult LogOut()
		{
			HttpContext.Response.Cookies.Append("X-Access-Token", "", new CookieOptions()
			{
				Expires = TimeHelper.GetCurrentServerTime().AddDays(-1)
			});
			return RedirectToAction("Index", "Home", new { area = "" });
		}

		[HttpGet("upaccount")]
		public async Task<ViewResult> UpAccount()
		{
			var user = await _userService.GetAsync(HttpContextHelper.UserId);
			var userUpdate = new UserUpdateDto()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				ImagePath = user.ImagePath,
				PhoneNumber = user.PhoneNumber,
			};
			return View("../Account/upaccount", userUpdate);
		}

		[HttpPost("upaccount")]
		public async Task<IActionResult> UpdateAsync([FromForm] UserUpdateDto userUpdateDto)
		{
			if (ModelState.IsValid)
			{
				bool result = await _service.UpdateAsync(HttpContextHelper.UserId, userUpdateDto);
				if (result)
					return RedirectToAction("Index", "Home", new { area = "" });
				else
					return RedirectToAction("upaccount", "Account", new { area = "" });
			}
			else return RedirectToAction("upaccount", "Account", new { area = "" });
		}
	}
}
