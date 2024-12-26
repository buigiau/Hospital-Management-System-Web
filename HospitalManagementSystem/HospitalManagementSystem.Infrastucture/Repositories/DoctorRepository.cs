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
	public class DoctorRepository : IDoctorRepository
	{
		private readonly ApplicationDbContext _context;

		public DoctorRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
		{
			return await _context.Doctors
								 .Include(d => d.Department)  
								 .ToListAsync();
		}


		public async Task<Doctor?> GetDoctorByIdAsync(Guid doctorId)
		{
			return await _context.Doctors.FindAsync(doctorId);
		}

		public async Task AddDoctorAsync(Doctor doctor)
		{
			_context.Doctors.Add(doctor);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateDoctorAsync(Doctor doctor)
		{
			_context.Doctors.Update(doctor);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteDoctorAsync(Guid doctorId)
		{
			var doctor = await _context.Doctors.FindAsync(doctorId);
			if (doctor != null)
			{
				_context.Doctors.Remove(doctor);
				await _context.SaveChangesAsync();
			}
		}
	}
}
