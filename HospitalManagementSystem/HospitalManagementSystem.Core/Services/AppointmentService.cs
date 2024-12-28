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
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepository;

		public AppointmentService(IAppointmentRepository appointmentRepository)
		{
			_appointmentRepository = appointmentRepository;
		}

		public async Task CreateAppointmentAsync(Appointment appointment)
		{
			if (appointment == null)
			{
				throw new ArgumentNullException(nameof(appointment));
			}

			await _appointmentRepository.CreateAppointmentAsync(appointment);
		}

		public async Task<Appointment?> GetAppointmentByIdAsync(Guid appointmentId)
		{
			if (appointmentId == Guid.Empty)
			{
				throw new ArgumentException("Appointment ID cannot be empty.", nameof(appointmentId));
			}

			return await _appointmentRepository.GetAppointmentByIdAsync(appointmentId);
		}

		public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
		{
			return await _appointmentRepository.GetAllAppointmentsAsync();
		}

		public async Task UpdateAppointmentAsync(Appointment appointment)
		{
			if (appointment == null)
			{
				throw new ArgumentNullException(nameof(appointment));
			}

			await _appointmentRepository.UpdateAppointmentAsync(appointment);
		}

		public async Task DeleteAppointmentAsync(Guid appointmentId)
		{
			if (appointmentId == Guid.Empty)
			{
				throw new ArgumentException("Appointment ID cannot be empty.", nameof(appointmentId));
			}

			await _appointmentRepository.DeleteAppointmentAsync(appointmentId);
		}
	}
}
