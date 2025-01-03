﻿using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using HospitalManagementSystem.Core.Services;
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
				Height = patient.Height,
				Weight = patient.Weight,
				BloodGroup = patient.BloodGroup,
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
		public async Task<IActionResult> Create(PatientDTO patientDto)
		{
			if (ModelState.IsValid)
			{
				await _patientService.AddAsync(patientDto);
				return RedirectToAction(nameof(Index));
			}
			return View(patientDto);
		}

		public async Task<IActionResult> ListToEdit()
		{

			List<Patient> patients = (List<Patient>)await _patientService.GetAllAsync();

			List<PatientDTO> patientDtos = patients.Select(patient => new PatientDTO
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
			return View(patientDtos);
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
				Address = patientEntity.Address,
				Height = patientEntity.Height,
				Weight = patientEntity.Weight,
				BloodGroup = patientEntity.BloodGroup,
			};

			return View(patientDTO);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(PatientDTO patientDTO)
		{
			if (ModelState.IsValid)
			{
				try
				{
					// Cập nhật thông tin bệnh nhân
					await _patientService.UpdatePatient(patientDTO);

					// Chuyển hướng đến trang chi tiết hoặc danh sách
					return RedirectToAction("ListToEdit"); // Hoặc trang chi tiết của bệnh nhân
				}
				catch (ArgumentException ex)
				{
					// Xử lý lỗi khi không tìm thấy bệnh nhân
					ModelState.AddModelError(string.Empty, ex.Message);
				}
				catch (Exception ex)
				{
					// Xử lý lỗi chung
					ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật bệnh nhân.");
				}
			}

			// Nếu có lỗi hoặc model không hợp lệ, hiển thị lại form
			return View(patientDTO);
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
