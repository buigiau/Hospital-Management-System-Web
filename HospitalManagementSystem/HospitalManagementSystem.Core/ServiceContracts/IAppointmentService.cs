using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.Domain.RepositoryContracts;
using HospitalManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.ServiceContracts
{
	public interface IAppointmentService
	{
		Task CreateAppointmentAsync(Appointment appointment);
		Task<Appointment?> GetAppointmentByIdAsync(Guid appointmentId);
		Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
		Task UpdateAppointmentAsync(Appointment appointment);
		Task DeleteAppointmentAsync(Guid appointmentId);
	}
}
