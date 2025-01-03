﻿using HospitalManagementSystem.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.RepositoryContracts
{
	public interface IAppointmentRepository
	{
		Task CreateAppointmentAsync(Appointment appointment);
		Task<Appointment?> GetAppointmentByIdAsync(Guid appointmentId);
		Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
		Task UpdateAppointmentAsync(Appointment appointment);
		Task DeleteAppointmentAsync(Guid appointmentId);
	}
}
