using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	public class PatientController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
