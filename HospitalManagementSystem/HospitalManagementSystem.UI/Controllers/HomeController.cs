using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
