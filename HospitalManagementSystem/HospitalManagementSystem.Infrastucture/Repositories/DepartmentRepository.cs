using Entites;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastucture.Repositories
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly ApplicationDbContext _context;

		public DepartmentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		// Create
		public async Task AddDepartmentAsync(Department department)
		{
			await _context.Departments.AddAsync(department);
			await _context.SaveChangesAsync();
		}

		// Read
		public async Task<Department> GetDepartmentByIdAsync(Guid id)
		{
			return await _context.Departments
								 .FirstOrDefaultAsync(d => d.DepartmentID == id);
		}

		public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
		{
			return await _context.Departments.ToListAsync();
		}

		// Update
		public async Task UpdateDepartmentAsync(Department department)
		{
			_context.Departments.Update(department);
			await _context.SaveChangesAsync();
		}

		// Delete
		public async Task DeleteDepartmentAsync(Guid id)
		{
			var department = await _context.Departments.FindAsync(id);
			if (department != null)
			{
				_context.Departments.Remove(department);
				await _context.SaveChangesAsync();
			}
		}
	}

}
