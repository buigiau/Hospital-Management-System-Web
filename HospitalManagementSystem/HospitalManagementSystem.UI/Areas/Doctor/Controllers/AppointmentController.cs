using Entites;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Doctor.Controllers
{
	[Area("Doctor")]
	[Authorize]
	public class AppointmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public AppointmentController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index(Guid doctorId)
		{
			var applicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(applicationUserId))
			{
				return Unauthorized(); // Người dùng chưa đăng nhập
			}

			// Tìm DoctorID tương ứng với ApplicationUserID
			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (doctor == null)
			{
				return NotFound("Can not find this doctor.");
			}

			// Retrieve the list of appointments with required details
			var appointments = await _context.Appointments
				.Where(a => a.DoctorID == doctor.DoctorID)
				.Include(a => a.Patient)
				.Include(a => a.Room)
				.Select(a => new AppointmentDTO
				{
					AppointmentID = a.AppointmentID,
					AppointmentDate = a.AppointmentDate,
					Status = a.Status,
					PatientFullName = $"{a.Patient.FirstName} {a.Patient.LastName}",  // Full name of the patient
					RoomNumber = a.Room != null ? a.Room.RoomNumber : 0, // Default room number to 0 if null
					Notes = a.Notes,
					DoctorID = a.DoctorID,
				})
				.ToListAsync();
				ViewBag.DoctorId = doctor.Id;
			// Return the appointments to the view
			return View(appointments);
		}

		[HttpPost]
		public async Task<IActionResult> AcceptAppointment(Guid appointmentId)
		{
			var appointment = await _context.Appointments
				.FirstOrDefaultAsync(a => a.AppointmentID == appointmentId);

			if (appointment == null)
			{
				return NotFound("Appointment not found.");
			}

			// Only update if the status is 'Scheduled'
			if (appointment.Status == "Scheduled")
			{
				appointment.Status = "Completed";
				await _context.SaveChangesAsync();
				TempData["SuccessMessage"] = "Appointment completed successfully.";
			}
			else
			{
				TempData["ErrorMessage"] = "This appointment cannot be completed.";
			}

			return RedirectToAction(nameof(Index)); // Redirect to the appointment list
		}

		[HttpPost]
		public async Task<IActionResult> CancelAppointment(Guid appointmentId)
		{
			var appointment = await _context.Appointments
				.FirstOrDefaultAsync(a => a.AppointmentID == appointmentId);

			if (appointment == null)
			{
				return NotFound("Appointment not found.");
			}

			// Only update if the status is 'Scheduled'
			if (appointment.Status == "Scheduled")
			{
				appointment.Status = "Cancelled";
				await _context.SaveChangesAsync();
				TempData["SuccessMessage"] = "Appointment canceled successfully.";
			}
			else
			{
				TempData["ErrorMessage"] = "This appointment cannot be canceled.";
			}

			return RedirectToAction(nameof(Index)); // Redirect to the appointment list
		}
	}

}
