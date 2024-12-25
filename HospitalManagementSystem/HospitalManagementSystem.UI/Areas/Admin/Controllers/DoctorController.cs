using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
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

		public async Task<IActionResult> Details(Guid id)
		{
			var doctor = await _doctorService.GetDoctorByIdAsync(id);
			if (doctor == null) return NotFound();

			return View(doctor);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DoctorDTO doctorDto)
		{
			if (ModelState.IsValid)
			{
				await _doctorService.AddDoctorAsync(doctorDto);
				return RedirectToAction(nameof(Index));
			}
			return View(doctorDto);
		}

		public async Task<IActionResult> Edit(Guid id)
		{
			var doctor = await _doctorService.GetDoctorByIdAsync(id);
			if (doctor == null) return NotFound();

			return View(doctor);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(DoctorDTO doctorDto)
		{
			if (ModelState.IsValid)
			{
				await _doctorService.UpdateDoctorAsync(doctorDto);
				return RedirectToAction(nameof(Index));
			}
			return View(doctorDto);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			var doctor = await _doctorService.GetDoctorByIdAsync(id);
			if (doctor == null) return NotFound();

			return View(doctor);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			await _doctorService.DeleteDoctorAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}