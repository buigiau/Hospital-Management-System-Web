using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
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


		// GET: Patient/Details/5
		public async Task<IActionResult> Details(Guid id)
		{

			var patient = await _patientService.GetByIdAsync(id);

			if (patient == null)
				return NotFound();


			var patientDto = new PatientDTO
			{
				PatientID = patient.PatientID,
				FirstName = patient.FirstName,
				LastName = patient.LastName,
				DateOfBirth = patient.DateOfBirth,
				Gender = patient.Gender,
				PhoneNumber = patient.PhoneNumber,
				Email = patient.Email,
				Address = patient.Address,
			};

			return View(patientDto);
		}


		// GET: Patient/Create
		public IActionResult Create()
		{
			return View();  // Trả về form tạo mới bệnh nhân
		}

		// POST: Patient/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] Patient patient)
		{
			if (!ModelState.IsValid)
				return View(patient);  // Trả lại form nếu có lỗi trong việc xác thực

			await _patientService.AddAsync(patient);
			return RedirectToAction(nameof(Index));  // Sau khi tạo, chuyển đến trang danh sách bệnh nhân
		}
		public async Task<IActionResult> ListToEdit()
		{
			// Lấy tất cả bệnh nhân dưới dạng Patient
			var patients = await _patientService.GetAllAsync();

			// Chuyển đổi từ danh sách Patient sang danh sách PatientDTO
			var patientDtos = patients.Select(patient => new PatientDTO
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

			return View(patientDtos);  // Trả về View để hiển thị danh sách bệnh nhân dưới dạng DTO
		}
		// GET: Patient/Edit/5
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			// Fetch patient details to populate the edit form
			var patientEntity = await _patientService.GetByIdAsync(id);
			if (patientEntity == null)
			{
				return NotFound();
			}

			var patientDTO = new PatientDTO
			{
				PatientID = patientEntity.PatientID,
				FirstName = patientEntity.FirstName,
				LastName = patientEntity.LastName,
				Email = patientEntity.Email,
				DateOfBirth = patientEntity.DateOfBirth,
				Gender = patientEntity.Gender,
				PhoneNumber = patientEntity.PhoneNumber,
				Address = patientEntity.Address
			};

			return View(patientDTO);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(PatientDTO patientDTO)
		{
			if (!ModelState.IsValid)
			{
				return View(patientDTO);
			}

			try
			{
				var updatedPatient = await _patientService.UpdatePatient(patientDTO);
				return RedirectToAction("Details", new { id = updatedPatient.PatientID });
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", $"An error occurred: {ex.Message}");
				return View(patientDTO);
			}
		}


		// GET: Patient/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			var patient = await _patientService.GetByIdAsync(id);
			if (patient == null)
				return NotFound();

			return View(patient);  // Trả về form xác nhận xóa bệnh nhân
		}

		// POST: Patient/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			await _patientService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));  // Sau khi xóa, chuyển đến trang danh sách bệnh nhân
		}
	}
}
