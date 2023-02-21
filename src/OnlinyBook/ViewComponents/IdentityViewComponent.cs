using Microsoft.AspNetCore.Mvc;
using OnlinyBook.Service.Intefaces.Common;
using OnlinyBook.Service.ViewModels.Accounts;

namespace OnlinyBook.ViewComponents
{
	public class IdentityViewComponent : ViewComponent
	{
		private readonly IIdentityService _identityService;
		public IdentityViewComponent(IIdentityService identity)
		{
			this._identityService = identity;
		}
		public IViewComponentResult Invoke()
		{
			AccountBaseViewModel accountBaseViewModel = new AccountBaseViewModel()
			{
				Id = _identityService.Id!.Value,
				Email = _identityService.Email,
				FirstName = _identityService.FirstName,
				LastName = _identityService.LastName,
				ImagePath = _identityService.ImagePath,
				Money = _identityService.Money

			};
			return View(accountBaseViewModel);
		}
	}

}
