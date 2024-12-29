using Entites;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using HospitalManagementSystem.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace HospitalManagementSystem.UI.Areas.Patients.Controllers
{
	[Area("Patient")]
	[Authorize]
	public class DoctorController : Controller
	{
		private readonly IDoctorService _doctorService;
		private readonly IAppointmentService _appointmentService;
		private readonly IPatientService _patientService;
		private readonly ApplicationDbContext _context;

		public DoctorController(IDoctorService doctorService, IAppointmentService appointmentService, IPatientService patientService, ApplicationDbContext context)
		{
			_doctorService = doctorService;
			_appointmentService = appointmentService;
			_patientService = patientService;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var doctors = await _doctorService.GetAllDoctorsAsync();
			return View(doctors);
		}

		public async Task<IActionResult> BookAppointment(Guid id)
		{
			var doctor = await _doctorService.GetDoctorByIdAsync(id);
			if (doctor == null) return NotFound();

			// Lấy Id từ Claims của người dùng đăng nhập (AccountID trong bảng ApplicationUser)
			var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
			if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
			{
				return Unauthorized(); // Nếu không có thông tin người dùng
			}

			Guid userId;
			if (!Guid.TryParse(userIdClaim.Value, out userId))
			{
				return BadRequest("Invalid User ID.");
			}

			// Truy vấn bảng Patients để lấy PatientID dựa trên AccountID (Id trong bảng Patient)
			var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == userId);
			if (patient == null)
			{
				return NotFound("Patient not found.");
			}

			// Truyền thông tin vào model
			var model = new AppointmentCreateDTO
			{
				DoctorID = id,
				DoctorName = $"{doctor.FirstName} {doctor.LastName}",
				PatientID = patient.PatientID // Lấy PatientID của bệnh nhân
			};
			return View(model);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SubmitAppointment(AppointmentCreateDTO model)
		{
			if (!ModelState.IsValid)
			{
				return View("BookAppointment", model);
			}

			Console.WriteLine(model.DoctorID);

			// Sử dụng PatientID đã được truyền từ model
			var patientId = model.PatientID;

			// Kiểm tra xem bệnh nhân có tồn tại trong cơ sở dữ liệu không
			var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientID == patientId);
			if (patient == null)
			{
				return NotFound("Patient not found.");
			}


			// Lấy tất cả các RoomID từ bảng Room
			var availableRooms = await _context.Rooms.ToListAsync();
			if (availableRooms == null || availableRooms.Count == 0)
			{
				return BadRequest("No available rooms.");
			}

			// Chọn một RoomID ngẫu nhiên
			var random = new Random();
			var randomRoom = availableRooms[random.Next(availableRooms.Count)];

			// Tạo mới Appointment và gán RoomID
			var appointment = new Appointment
			{
				AppointmentID = Guid.NewGuid(),
				DoctorID = model.DoctorID,
				PatientID = patient.PatientID,
				AppointmentDate = model.AppointmentDate,
				Status = "Scheduled",
				Notes = model.Notes,
				RoomID = randomRoom.RoomID // Gán RoomID ngẫu nhiên vào Appointment
			};

			await _appointmentService.CreateAppointmentAsync(appointment);

			TempData["SuccessMessage"] = "Appointment booked successfully!";
			return RedirectToAction("Index");
		}
	}
}
