using Entites;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Doctor.Controllers
{
	[Area("Doctor")]
	[Authorize]
	public class TreatmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public TreatmentController(ApplicationDbContext context)
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

			// Tìm PatientID tương ứng với ApplicationUserID
			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (doctor == null)
			{
				return NotFound("Can not find this doctor.");
			}

			var treatments = await _context.Treatments
				.Where(t => t.DoctorID == doctor.DoctorID)
				.Include(t => t.Patient)
				.Select(t => new TreatmentDTO
				{
					TreatmentID = t.TreatmentID,
					TreatmentDate = t.TreatmentDate,
					TreatmentDetail = t.TreatmentDetails,
					PatientFullName = t.Patient != null ? $"{t.Patient.FirstName} {t.Patient.LastName}" : "Unknown",
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

			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (doctor == null)
			{
				return NotFound("Can not find your information.");
			}

			var treatment = await _context.Treatments
				.Where(t => t.TreatmentID == treatmentId && t.DoctorID == doctor.DoctorID)
				.Include(t => t.Doctor)
				.FirstOrDefaultAsync();

			if (treatment == null)
			{
				return NotFound("Can not find your treatment details.");
			}

			// Lưu patientId vào ViewData để có thể quay lại danh sách
			ViewData["DoctorId"] = doctor.DoctorID;

			var treatmentDetail = new TreatmentDTO
			{
				TreatmentID = treatment.TreatmentID,
				TreatmentDate = treatment.TreatmentDate,
				TreatmentDetail = treatment.TreatmentDetails,
				PatientFullName = treatment.Patient != null ? $"{treatment.Patient.FirstName} {treatment.Patient.LastName}" : "Unknown",
				FollowUpDate = treatment.FollowUpDate,
				TreatmentTitle = treatment.Title
			};

			return View(treatmentDetail);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid treatmentId)
		{
			var applicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(applicationUserId))
			{
				return Unauthorized();
			}

			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (doctor == null)
			{
				return NotFound("Can not find your information.");
			}

			var treatment = await _context.Treatments
				.Where(t => t.TreatmentID == treatmentId && t.DoctorID == doctor.DoctorID)
				.FirstOrDefaultAsync();

			if (treatment == null)
			{
				return NotFound("Can not find the treatment.");
			}

			return View(treatment); // Truyền treatment vào View để hiển thị form
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid treatmentId)
		{
			var treatment = await _context.Treatments.FindAsync(treatmentId);
			if (treatment == null) return NotFound();

			return View(treatment);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid treatmentId, Treatment updatedTreatment)
		{
			var applicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(applicationUserId))
			{
				return Unauthorized();
			}

			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (doctor == null)
			{
				return NotFound("Can not find your information.");
			}

			var treatment = await _context.Treatments
				.Where(t => t.TreatmentID == treatmentId && t.DoctorID == doctor.DoctorID)
				.FirstOrDefaultAsync();

			if (treatment == null)
			{
				return NotFound("Can not find the treatment.");
			}

			// Cập nhật thông tin
			treatment.Title = updatedTreatment.Title;
			treatment.TreatmentDetails = updatedTreatment.TreatmentDetails;
			treatment.TreatmentDate = updatedTreatment.TreatmentDate;
			treatment.FollowUpDate = updatedTreatment.FollowUpDate;

			_context.Treatments.Update(treatment);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid treatmentId)
		{
			var applicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(applicationUserId))
			{
				return Unauthorized();
			}

			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (doctor == null)
			{
				return NotFound("Can not find your information.");
			}

			var treatment = await _context.Treatments
				.Where(t => t.TreatmentID == treatmentId && t.DoctorID == doctor.DoctorID)
				.FirstOrDefaultAsync();

			if (treatment == null)
			{
				return NotFound("Can not find the treatment.");
			}

			_context.Treatments.Remove(treatment);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}
}