using Entites;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Patients.Controllers
{
	[Area("Patient")]
	[Authorize]
	public class PrescriptionController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PrescriptionController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(Guid patientId)
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
				return NotFound("Không tìm thấy thông tin bệnh nhân của bạn.");
			}

			var prescriptions = await _context.Prescriptions
				.Where(p => p.Treatment.PatientID == patient.PatientID)
				.Select(p => new 
				{
					PrescriptionID = p.PresciptionID,
					MedicationName = p.MedicationName,
					Dosage = p.Dosage,
					Instruction = p.Instruction,
					TreatmentDate = p.Treatment.TreatmentDate,
					DoctorFullName = p.Treatment.Doctor != null ? $"{p.Treatment.Doctor.FirstName} {p.Treatment.Doctor.LastName}" : "Unknown",
					Title = p.Treatment.Title
				})
				.ToListAsync();

			return View(prescriptions);
		}
	}
}
