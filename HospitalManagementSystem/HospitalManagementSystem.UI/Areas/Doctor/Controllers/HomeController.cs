using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Areas.Doctor.Controllers
{
	[Area("Doctor")]
	[Authorize]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
