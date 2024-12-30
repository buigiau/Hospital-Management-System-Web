using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using HospitalManagementSystem.Core.Services;
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
				return RedirectToAction(nameof(ListToEdit));
			}
			return View(doctorDto);
		}

		public async Task<IActionResult> ListToEdit()
		{
			var doctors = await _doctorService.GetAllDoctorsAsync();
			return View(doctors);
		}
		public async Task<IActionResult> Edit(Guid id)
		{
			var doctor = await _doctorService.GetDoctorByIdAsync(id);
			if (doctor == null) return NotFound();

			return View(doctor);
		}

		/*[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(DoctorDTO doctorDto)
		{
			if (ModelState.IsValid)
			{
				await _doctorService.UpdateDoctorAsync(doctorDto);
				return RedirectToAction(nameof(Index));
			}
			return View(doctorDto);
		}*/
		[HttpPost]
		public async Task<IActionResult> Edit(DoctorDTO doctorDTO)
		{
			if (ModelState.IsValid)
			{
				try
				{
					// Cập nhật thông tin bệnh nhân
					await _doctorService.UpdateDoctorAsync(doctorDTO);

					// Chuyển hướng đến trang chi tiết hoặc danh sách
					return RedirectToAction("ListToEdit"); // Hoặc trang chi tiết của bệnh nhân
				}
				catch (ArgumentException ex)
				{
					// Xử lý lỗi khi không tìm thấy bệnh nhân
					ModelState.AddModelError(string.Empty, ex.Message);
				}
				catch (Exception ex)
				{
					// Xử lý lỗi chung
					ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật bệnh nhân.");
				}
			}

			// Nếu có lỗi hoặc model không hợp lệ, hiển thị lại form
			return View(doctorDTO);
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
			return RedirectToAction(nameof(ListToEdit));
		}
	}
}