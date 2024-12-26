using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Patients.Controllers
{
	[Area("Patient")]
	[Authorize]
	public class AppointmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public AppointmentController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(Guid patientId)
		{
			var applicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(applicationUserId))
			{
				return Unauthorized(); // Người dùng chưa đăng nhập
			}

			// Tìm PatientID tương ứng với ApplicationUserID
			var patient = await _context.Patients
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (patient == null)
			{
				return NotFound("Không tìm thấy thông tin bệnh nhân của bạn.");
			}

			// Lấy danh sách cuộc hẹn của bệnh nhân
			var appointments = await _context.Appointments
				.Where(a => a.PatientID == patient.PatientID)
				.Include(a => a.Doctor)
				.Include(a => a.Room)
				.Select(a => new
				{
					AppointmentID = a.AppointmentID,
					AppointmentDate = a.AppointmentDate,
					Status = a.Status,
					DoctorFullName = a.Doctor != null ? $"{a.Doctor.FirstName} {a.Doctor.LastName}" : "Unknown",
					RoomNumber = a.Room != null ? a.Room.RoomNumber : 0, // Đảm bảo không bị null
					Notes = a.Notes
				})
				.ToListAsync();

			return View(appointments);
		}
	}
}
