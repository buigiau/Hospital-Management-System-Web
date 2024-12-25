using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService _departmentService;

		// Constructor tiêm service vào controller
		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		// GET: Department
		public async Task<IActionResult> Index()
		{

			var departments = await _departmentService.GetAllDepartmentsAsync();

			var departmentDTOs = departments.Select(department => new DepartmentDTO
			{
				DepartmentID = department.DepartmentID,
				Name = department.Name,
				Description = department.Description
			}).ToList();

			return View(departmentDTOs);
		}

		// GET: Department/Details/5
		public async Task<IActionResult> Details(Guid id)
		{
			var department = await _departmentService.GetDepartmentByIdAsync(id);
			if (department == null)
			{
				return NotFound();
			}

			var departmentDTO = new DepartmentDTO
			{
				DepartmentID = department.DepartmentID,
				Name = department.Name,
				Description = department.Description
			};

			return View(departmentDTO); // Trả về DepartmentDTO
		}


		// GET: Department/Create
		public IActionResult Create()
		{
			// Trả về view tạo mới department
			return View();
		}

		// POST: Department/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DepartmentDTO departmentDTO)
		{
			if (ModelState.IsValid)
			{
				var department = new Department
				{
					DepartmentID = Guid.NewGuid(),
					Name = departmentDTO.Name,
					Description = departmentDTO.Description
				};

				await _departmentService.AddDepartmentAsync(department);
				return RedirectToAction(nameof(Index));
			}

			return View(departmentDTO);
		}


		// GET: Department/Edit/5
		public async Task<IActionResult> Edit(Guid id)
		{
			var department = await _departmentService.GetDepartmentByIdAsync(id);
			if (department == null)
			{
				return NotFound();
			}

			var departmentDTO = new DepartmentDTO
			{
				DepartmentID = department.DepartmentID,
				Name = department.Name,
				Description = department.Description
			};

			return View(departmentDTO);
		}

		// POST: Department/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, DepartmentDTO departmentDTO)
		{
			if (id != departmentDTO.DepartmentID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					// Lấy đối tượng Department cũ từ cơ sở dữ liệu
					var department = await _departmentService.GetDepartmentByIdAsync(id);
					if (department == null)
					{
						return NotFound();
					}

					// Cập nhật các thuộc tính của đối tượng cũ
					department.Name = departmentDTO.Name;
					department.Description = departmentDTO.Description;

					// Cập nhật vào cơ sở dữ liệu
					await _departmentService.UpdateDepartmentAsync(department);
				}
				catch (Exception)
				{
					if (await _departmentService.GetDepartmentByIdAsync(id) == null)
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}

			return View(departmentDTO);
		}


		// GET: Department/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			var department = await _departmentService.GetDepartmentByIdAsync(id);
			if (department == null)
			{
				return NotFound();
			}

			var departmentDTO = new DepartmentDTO
			{
				DepartmentID = department.DepartmentID,
				Name = department.Name,
				Description = department.Description
			};

			return View(departmentDTO);
		}


		// POST: Department/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			// Xóa department theo ID
			await _departmentService.DeleteDepartmentAsync(id);
			return RedirectToAction(nameof(Index));
		}

		// Kiểm tra nếu department tồn tại
		private async Task<bool> DepartmentExists(Guid id)
		{
			var department = await _departmentService.GetDepartmentByIdAsync(id);
			return department != null;
		}
	}
}
