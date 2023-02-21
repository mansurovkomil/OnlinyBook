using Microsoft.AspNetCore.Mvc;
using OnlinyBook.Service.ViewModels.Contacts;

namespace OnlinyBook.Controllers
{
	public class ContactsController : Controller
	{
		public IActionResult Index() //contacts
		{
			return View();
		}

		[HttpPost]
		public IActionResult Check(ContactViewModel contact) //contacts
		{
			if (ModelState.IsValid)
			{
				return Redirect("/");
			}
			return View("Index");
		}
	}
}
