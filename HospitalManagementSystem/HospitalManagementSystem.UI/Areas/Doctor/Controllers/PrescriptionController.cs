using Entites;
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
	}
}
