using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	public class DoctorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
