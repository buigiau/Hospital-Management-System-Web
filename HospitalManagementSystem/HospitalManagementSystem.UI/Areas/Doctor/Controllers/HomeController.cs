using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Doctor.Controllers
{
	[Area("Doctor")]
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}
		/*		public async Task<IActionResult> Index(Guid id)
				{
					var doctor = await _context.Doctors.Include(d => d.Department)
						.FirstOrDefaultAsync(p => p.ApplicationUser.Id == id);
					if (doctor == null)
						return NotFound();
					ViewBag.DoctorId = doctor.Id;
					return View(doctor);
				}*/

		public async Task<IActionResult> Index(Guid id)
		{
			var doctor = await _context.Doctors
				.Include(d => d.Department)
				.Include(d => d.Treatments)
					.ThenInclude(t => t.Patient)
				.Include(d => d.Appointments)
					.ThenInclude(a => a.Patient)
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == id);

			if (doctor == null)
				return NotFound();

			// Tạo danh sách bệnh nhân từ Treatment và Appointment
			var patients = doctor.Treatments.Select(t => t.Patient)
							.Concat(doctor.Appointments.Select(a => a.Patient))
							.Distinct()
							.ToList();

			// Tạo số liệu cho biểu đồ appointments trong tuần (dữ liệu giả định hoặc thực tế từ Appointment)
			var appointmentCounts = new int[7]; // Mảng để lưu số lượng appointment cho mỗi ngày trong tuần

			foreach (var appointment in doctor.Appointments)
			{
				var dayOfWeek = appointment.AppointmentDate.DayOfWeek;
				appointmentCounts[(int)dayOfWeek]++;
			}

			// Truyền dữ liệu vào View
			ViewBag.AppointmentCounts = appointmentCounts;
			ViewBag.Patients = patients;
			ViewBag.DoctorId = doctor.Id;

			return View(doctor);
		}
	}
}
