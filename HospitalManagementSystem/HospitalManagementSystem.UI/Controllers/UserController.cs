using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystem.UI.Controllers
{
	[AllowAnonymous]
	public class UserController : Controller
	{
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
	}
}
