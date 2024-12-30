using Entites;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class TreatmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public TreatmentController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var treatments = await _context.Treatments
				.Include(t => t.Doctor)
				.Include(t => t.Patient)
				.ToListAsync();

			return View(treatments);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			// Truy vấn trực tiếp để lấy dữ liệu cần thiết
			var treatment = await _context.Treatments
				.Include(t => t.Doctor)
				.Include(t => t.Patient)
				.Where(t => t.TreatmentID == id)
				.Select(t => new TreatmentDTO
				{
					TreatmentID = t.TreatmentID,
					TreatmentDate = t.TreatmentDate,
					TreatmentDetail = t.TreatmentDetails,
					TreatmentTitle = t.Title,
					FollowUpDate = t.FollowUpDate,
					DoctorFullName = t.Doctor != null ? $"{t.Doctor.FirstName} {t.Doctor.LastName}" : "Unknown",
					PatientFullName = t.Patient != null ? $"{t.Patient.FirstName} {t.Patient.LastName}" : "Unknown"
				})
				.FirstOrDefaultAsync();

			if (treatment == null)
			{
				return NotFound();
			}

			return View(treatment); // Trả về DTO cho View
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, TreatmentDTO treatmentDto)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}

			var treatment = await _context.Treatments.FirstOrDefaultAsync(t => t.TreatmentID == id);
			if (treatment == null)
			{
				return NotFound();
			}

			treatment.TreatmentDate = treatmentDto.TreatmentDate;
			treatment.TreatmentDetails = treatmentDto.TreatmentDetail;
			treatment.Title = treatmentDto.TreatmentTitle;
			treatment.FollowUpDate = treatmentDto.FollowUpDate;

			try
			{
				_context.Update(treatment);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}
		}

		private bool TreatmentExists(Guid id)
		{
			return _context.Treatments.Any(t => t.TreatmentID == id);
		}
		public IActionResult Create()
		{
			ViewData["Doctors"] = _context.Doctors.ToList();
			ViewData["Patients"] = _context.Patients.ToList();
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TreatmentDTO treatmentDTO)
		{
			if (!ModelState.IsValid)
			{
				ViewData["Doctors"] = await _context.Doctors.ToListAsync();
				ViewData["Patients"] = await _context.Patients.ToListAsync();
				return View(treatmentDTO);
			}

			var doctorExists = await _context.Doctors.AnyAsync(d => d.DoctorID == treatmentDTO.DoctorID);
			if (!doctorExists)
			{
				ModelState.AddModelError("DoctorID", "Doctor ID does not exist in the database.");
			}

			var patientExists = await _context.Patients.AnyAsync(p => p.PatientID == treatmentDTO.PatientID);
			if (!patientExists)
			{
				ModelState.AddModelError("PatientID", "Patient ID does not exist in the database.");
			}

			if (!ModelState.IsValid)
			{
				ViewData["Doctors"] = await _context.Doctors.ToListAsync();
				ViewData["Patients"] = await _context.Patients.ToListAsync();
				return View(treatmentDTO);
			}

			// Populate Doctor and Patient Full Names
			var doctor = await _context.Doctors.FindAsync(treatmentDTO.DoctorID);
			var patient = await _context.Patients.FindAsync(treatmentDTO.PatientID);

			treatmentDTO.DoctorFullName = $"{doctor?.FirstName} {doctor?.LastName}";
			treatmentDTO.PatientFullName = $"{patient?.FirstName} {patient?.LastName}";

			var treatment = new Treatment
			{
				TreatmentID = Guid.NewGuid(),
				TreatmentDate = treatmentDTO.TreatmentDate ?? DateTime.Now,
				TreatmentDetails = treatmentDTO.TreatmentDetail,
				Title = treatmentDTO.TreatmentTitle,
				FollowUpDate = treatmentDTO.FollowUpDate,
				DoctorID = treatmentDTO.DoctorID,
				PatientID = treatmentDTO.PatientID
			};

			_context.Treatments.Add(treatment);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}

			var treatment = await _context.Treatments
				.Include(t => t.Doctor)
				.Include(t => t.Patient)
				.FirstOrDefaultAsync(t => t.TreatmentID == id);

			if (treatment == null)
			{
				return NotFound();
			}

			var treatmentDto = new TreatmentDTO
			{
				TreatmentID = treatment.TreatmentID,
				TreatmentDate = treatment.TreatmentDate,
				TreatmentDetail = treatment.TreatmentDetails,
				TreatmentTitle = treatment.Title,
				FollowUpDate = treatment.FollowUpDate,
				DoctorFullName = treatment.Doctor != null ? $"{treatment.Doctor.FirstName} {treatment.Doctor.LastName}" : "Unknown",
				PatientFullName = treatment.Patient != null ? $"{treatment.Patient.FirstName} {treatment.Patient.LastName}" : "Unknown"
			};

			return View(treatmentDto);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest(); // Kiểm tra ID hợp lệ
			}

			var treatment = await _context.Treatments.FirstOrDefaultAsync(t => t.TreatmentID == id);

			if (treatment == null)
			{
				return NotFound(); // Xử lý khi không tìm thấy Treatment
			}

			try
			{
				_context.Treatments.Remove(treatment);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
			}
			catch (DbUpdateException ex)
			{
				// Log lỗi nếu cần
				ModelState.AddModelError(string.Empty, "Unable to delete the treatment. Please try again later.");
				return View("Error", ex); // Hiển thị trang lỗi nếu cần
			}
		}
	}
}
