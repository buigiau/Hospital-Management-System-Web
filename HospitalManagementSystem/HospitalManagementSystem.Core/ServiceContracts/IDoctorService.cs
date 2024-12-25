using HospitalManagementSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.ServiceContracts
{
	public interface IDoctorService
	{
		Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync();
		Task<DoctorDTO?> GetDoctorByIdAsync(Guid doctorId);
		Task AddDoctorAsync(DoctorDTO doctorDto);
		Task UpdateDoctorAsync(DoctorDTO doctorDto);
		Task DeleteDoctorAsync(Guid doctorId);
	}
}
