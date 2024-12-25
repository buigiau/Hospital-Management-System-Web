using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.Domain.RepositoryContracts;
using HospitalManagementSystem.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		// Create
		public async Task AddDepartmentAsync(Department department)
		{
			// Thực hiện logic nghiệp vụ nếu cần
			await _departmentRepository.AddDepartmentAsync(department);
		}

		// Read
		public async Task<Department> GetDepartmentByIdAsync(Guid id)
		{
			return await _departmentRepository.GetDepartmentByIdAsync(id);
		}

		public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
		{
			return await _departmentRepository.GetAllDepartmentsAsync();
		}

		// Update
		public async Task UpdateDepartmentAsync(Department department)
		{
			// Thực hiện kiểm tra bổ sung nếu cần
			await _departmentRepository.UpdateDepartmentAsync(department);
		}

		// Delete
		public async Task DeleteDepartmentAsync(Guid id)
		{
			// Kiểm tra thêm logic trước khi xóa nếu cần
			await _departmentRepository.DeleteDepartmentAsync(id);
		}
	}

}
