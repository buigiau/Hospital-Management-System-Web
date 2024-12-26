using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.ServiceContracts
{
	public interface IPatientService
	{
		Task<IEnumerable<Patient>> GetAllAsync();
		Task<Patient> GetByIdAsync(Guid id);
		Task AddAsync(PatientDTO patientDto);
		Task<PatientDTO> UpdatePatient(PatientDTO? patientDTO);
		Task DeleteAsync(Guid id);

	}
}
