using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Areas.Doctor.Controllers
{
	[Area("Doctor")]
	[Authorize]
	public class PatientController : Controller
	{
		private readonly IPatientService _patientService;
		public PatientController(IPatientService patientService)
		{
			_patientService = patientService;
		}
		public async Task<IActionResult> Index(int page = 1, int pageSize = 7)
		{

			List<Patient> patients = (List<Patient>)await _patientService.GetAllAsync();

			// Phân trang
			var pagedPatients = patients
				.OrderByDescending(p => p.FirstName)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			List<PatientDTO> patientDtos = pagedPatients.Select(patient => new PatientDTO
			{
				PatientID = patient.PatientID,
				FirstName = patient.FirstName,
				LastName = patient.LastName,
				DateOfBirth = patient.DateOfBirth,
				Gender = patient.Gender,
				Email = patient.Email,
				PhoneNumber = patient.PhoneNumber,
				Address = patient.Address,
			}).ToList();

			ViewBag.CurrentPage = page;
			ViewBag.TotalPages = (int)Math.Ceiling((double)patients.Count / pageSize);

			return View(patientDtos);
		}

	}
}
