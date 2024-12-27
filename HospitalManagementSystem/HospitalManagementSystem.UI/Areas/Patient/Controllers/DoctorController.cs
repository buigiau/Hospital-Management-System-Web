using HospitalManagementSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Areas.Patients.Controllers
{
	[Area("Patient")]
	[Authorize]
	public class DoctorController : Controller
	{
		private readonly IDoctorService _doctorService;

		public DoctorController(IDoctorService doctorService)
		{
			_doctorService = doctorService;
		}
		public async Task<IActionResult> Index()
		{
			var doctors = await _doctorService.GetAllDoctorsAsync();
			return View(doctors);
		}
	}
}
