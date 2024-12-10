using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Core.DTO;

namespace HospitalManagementSystem.UI.Controllers
{
	public class UserController : Controller
	{
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

	}
}
