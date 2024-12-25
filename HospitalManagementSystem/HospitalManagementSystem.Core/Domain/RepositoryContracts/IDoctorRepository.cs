using HospitalManagementSystem.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.RepositoryContracts
{
	public interface IDoctorRepository
	{
		Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
		Task<Doctor?> GetDoctorByIdAsync(Guid doctorId);
		Task AddDoctorAsync(Doctor doctor);
		Task UpdateDoctorAsync(Doctor doctor);
		Task DeleteDoctorAsync(Guid doctorId);
	}
}
