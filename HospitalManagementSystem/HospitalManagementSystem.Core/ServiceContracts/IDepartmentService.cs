using HospitalManagementSystem.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.ServiceContracts
{
	public interface IDepartmentService
	{
		// Create
		Task AddDepartmentAsync(Department department);

		// Read
		Task<Department> GetDepartmentByIdAsync(Guid id);
		Task<IEnumerable<Department>> GetAllDepartmentsAsync();

		// Update
		Task UpdateDepartmentAsync(Department department);

		// Delete
		Task DeleteDepartmentAsync(Guid id);
	}

}
