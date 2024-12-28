using Entites;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Patients.Controllers
{
	[Area("Patient")]
	[Authorize]
	public class TreatmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public TreatmentController(ApplicationDbContext context)
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

			var treatments = await _context.Treatments
				.Where(t => t.PatientID == patient.PatientID)
				.Include(t => t.Doctor)
				.Select(t => new TreatmentDTO
				{
					TreatmentID = t.TreatmentID,
					TreatmentDate = t.TreatmentDate,
					TreatmentDetail = t.TreatmentDetails,
					DoctorFullName = t.Doctor != null ? $"{t.Doctor.FirstName} {t.Doctor.LastName}" : "Unknown",
					FollowUpDate = t.FollowUpDate,
					TreatmentTitle = t.Title
				})
				.ToListAsync();

			return View(treatments);
		}
		public async Task<IActionResult> Details(Guid treatmentId)
		{
			var applicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(applicationUserId))
			{
				return Unauthorized();
			}

			var patient = await _context.Patients
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (patient == null)
			{
				return NotFound("Can not find your information.");
			}

			var treatment = await _context.Treatments
				.Where(t => t.TreatmentID == treatmentId && t.PatientID == patient.PatientID)
				.Include(t => t.Doctor)
				.FirstOrDefaultAsync();

			if (treatment == null)
			{
				return NotFound("Can not find your treatment details.");
			}

			// Lưu patientId vào ViewData để có thể quay lại danh sách
			ViewData["PatientId"] = patient.PatientID;

			var treatmentDetail = new TreatmentDTO
			{
				TreatmentID = treatment.TreatmentID,
				TreatmentDate = treatment.TreatmentDate,
				TreatmentDetail = treatment.TreatmentDetails,
				DoctorFullName = treatment.Doctor != null ? $"{treatment.Doctor.FirstName} {treatment.Doctor.LastName}" : "Unknown",
				FollowUpDate = treatment.FollowUpDate,
				TreatmentTitle = treatment.Title
			};

			return View(treatmentDetail);
		}

	}
}
