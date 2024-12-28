using Entites;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Doctor.Controllers
{
	[Area("Doctor")]
	[Authorize]
	public class PrescriptionController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PrescriptionController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(Guid doctorId)
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
				return NotFound("Can not find this doctor.");
			}

			var prescriptions = await _context.Prescriptions
				.Where(p => p.Treatment.DoctorID == doctor.DoctorID)
				.Select(p => new
				{
					PrescriptionID = p.PresciptionID,
					MedicationName = p.MedicationName,
					Dosage = p.Dosage,
					Instruction = p.Instruction,
					TreatmentDate = p.Treatment.TreatmentDate,
					PatientFullName = p.Treatment.Patient != null ? $"{p.Treatment.Patient.FirstName} {p.Treatment.Patient.LastName}" : "Unknown",
					Title = p.Treatment.Title
				})
				.ToListAsync();

			return View(prescriptions);
		}
		[HttpGet]
		public async Task<IActionResult> Delete(Guid prescriptionId)
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
				return NotFound("Cannot find this doctor.");
			}

			var prescription = await _context.Prescriptions
				.Where(p => p.PresciptionID == prescriptionId && p.Treatment.DoctorID == doctor.DoctorID)
				.Select(p => new PrescriptionDTO
				{
					PrescriptionID = p.PresciptionID,
					MedicationName = p.MedicationName,
					Dosage = p.Dosage,
					Instruction = p.Instruction,
					TreatmentDate = p.Treatment.TreatmentDate,
					PatientFullName = p.Treatment.Patient != null ? $"{p.Treatment.Patient.FirstName} {p.Treatment.Patient.LastName}" : "Unknown",
					Title = p.Treatment.Title
				})
				.FirstOrDefaultAsync();

			if (prescription == null)
			{
				return NotFound("Prescription not found.");
			}

			return View(prescription);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid prescriptionId)
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
				return NotFound("Cannot find this doctor.");
			}

			var prescription = await _context.Prescriptions
				.Where(p => p.PresciptionID == prescriptionId && p.Treatment.DoctorID == doctor.DoctorID)
				.FirstOrDefaultAsync();

			if (prescription == null)
			{
				return NotFound("Prescription not found.");
			}

			_context.Prescriptions.Remove(prescription);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index), new { doctorId = doctor.DoctorID });
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid prescriptionId)
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
				return NotFound("Cannot find this doctor.");
			}

			var prescription = await _context.Prescriptions
				.Where(p => p.PresciptionID == prescriptionId && p.Treatment.DoctorID == doctor.DoctorID)
				.Select(p => new PrescriptionDTO
				{
					PrescriptionID = p.PresciptionID,
					MedicationName = p.MedicationName,
					Dosage = p.Dosage,
					Instruction = p.Instruction,
					TreatmentDate = p.Treatment.TreatmentDate,
					PatientFullName = p.Treatment.Patient != null ? $"{p.Treatment.Patient.FirstName} {p.Treatment.Patient.LastName}" : "Unknown",
					Title = p.Treatment.Title
				})
				.FirstOrDefaultAsync();

			if (prescription == null)
			{
				return NotFound("Prescription not found.");
			}

			return View(prescription);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditConfirmed(PrescriptionDTO prescriptionDto)
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
				return NotFound("Cannot find this doctor.");
			}

	
			var prescription = await _context.Prescriptions
				.Where(p => p.PresciptionID == prescriptionDto.PrescriptionID && p.Treatment.DoctorID == doctor.DoctorID)
				.FirstOrDefaultAsync();

			if (prescription == null)
			{
				return NotFound("Prescription not found.");
			}


			prescription.MedicationName = prescriptionDto.MedicationName;
			prescription.Dosage = prescriptionDto.Dosage;
			prescription.Instruction = prescriptionDto.Instruction;

			_context.Prescriptions.Update(prescription);
			await _context.SaveChangesAsync();


			return RedirectToAction(nameof(Index), new { doctorId = doctor.DoctorID });
		}
	}
}
