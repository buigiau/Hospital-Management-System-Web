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
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public AppointmentRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateAppointmentAsync(Appointment appointment)
		{
			await _dbContext.Appointments.AddAsync(appointment);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Appointment?> GetAppointmentByIdAsync(Guid appointmentId)
		{
			return await _dbContext.Appointments
				.Include(a => a.Doctor)
				.Include(a => a.Patient)
				.FirstOrDefaultAsync(a => a.AppointmentID == appointmentId);
		}

		public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
		{
			return await _dbContext.Appointments
				.Include(a => a.Doctor)
				.Include(a => a.Patient)
				.ToListAsync();
		}

		public async Task UpdateAppointmentAsync(Appointment appointment)
		{
			_dbContext.Appointments.Update(appointment);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAppointmentAsync(Guid appointmentId)
		{
			var appointment = await GetAppointmentByIdAsync(appointmentId);
			if (appointment != null)
			{
				_dbContext.Appointments.Remove(appointment);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
