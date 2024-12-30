using HospitalManagementSystem.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.RepositoryContracts
{
	public interface IPatientRepository
	{
		Task<IEnumerable<Patient>> GetAllAsync();
		Task<Patient> GetByIdAsync(Guid id);
		Task AddAsync(Patient patient);
		Task UpdatePatient(Patient patient);
		Task DeleteAsync(Guid id);
	}
}
