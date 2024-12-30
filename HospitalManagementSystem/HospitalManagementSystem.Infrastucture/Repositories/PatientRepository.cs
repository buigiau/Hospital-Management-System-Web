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
	public class PatientRepository : IPatientRepository
	{
		private readonly ApplicationDbContext _context;

		public PatientRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Patient>> GetAllAsync()
		{
			return await _context.Patients.ToListAsync();
		}

		public async Task<Patient> GetByIdAsync(Guid id)
		{
			return await _context.Patients
								 .FirstOrDefaultAsync(p => p.PatientID == id);
		}

		public async Task AddAsync(Patient patient)
		{
			_context.Patients.Add(patient);
			await _context.SaveChangesAsync();
		}

		public async Task UpdatePatient(Patient patient)
		{
			_context.Patients.Update(patient);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var patient = await GetByIdAsync(id);
			if (patient != null)
			{
				_context.Patients.Remove(patient);
				await _context.SaveChangesAsync();
			}
		}
	}
}
