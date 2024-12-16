using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.Domain.IndentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entites
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public virtual DbSet<Doctor> Doctors { get; set; }
		public virtual DbSet<Patient> Patients { get; set; }
		public virtual DbSet<Appointment> Appointments { get; set; }
		public virtual DbSet<Department> Departments { get; set; }
		public virtual DbSet<Invoice> Invoices { get; set; }
		public virtual DbSet<Prescription> Prescriptions { get; set; }
		public virtual DbSet<Room> Rooms { get; set; }
		public virtual DbSet<Treatment> Treatments { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Department -> Doctors (1-N)
			modelBuilder.Entity<Doctor>()
				.HasOne(d => d.Department)
				.WithMany(dep => dep.Doctors)
				.HasForeignKey(d => d.DepartmentID);

			// Department -> Rooms (1-N)
			modelBuilder.Entity<Room>()
				.HasOne(r => r.Department)
				.WithMany(dep => dep.Rooms)
				.HasForeignKey(r => r.DepartmentID);

			// Doctor -> Treatments (1-N)
			modelBuilder.Entity<Treatment>()
				.HasOne(t => t.Doctor)
				.WithMany(doc => doc.Treatments)
				.HasForeignKey(t => t.DoctorID);

			// Patient -> Treatments (1-N)
			modelBuilder.Entity<Treatment>()
				.HasOne(t => t.Patient)
				.WithMany(p => p.Treatments)
				.HasForeignKey(t => t.PatientID);

			// Treatment -> Prescriptions (1-N)
			modelBuilder.Entity<Prescription>()
				.HasOne(pres => pres.Treatment)
				.WithMany(t => t.Prescriptions)
				.HasForeignKey(pres => pres.TreatmentID);

			// Treatment -> Invoices (1-N)
			modelBuilder.Entity<Invoice>()
				.HasOne(inv => inv.Treatment)
				.WithMany(t => t.Invoices)
				.HasForeignKey(inv => inv.TreatmentID);

			// Room -> Appointments (1-N)
			modelBuilder.Entity<Appointment>()
				.HasOne(app => app.Room)
				.WithMany(r => r.Appointments)
				.HasForeignKey(app => app.RoomID);

			// Doctor -> Appointments (1-N)
			modelBuilder.Entity<Appointment>()
				.HasOne(app => app.Doctor)
				.WithMany(d => d.Appointments)
				.HasForeignKey(app => app.DoctorID);

			// Patient -> Appointments (1-N)
			modelBuilder.Entity<Appointment>()
				.HasOne(app => app.Patient)
				.WithMany(p => p.Appointments)
				.HasForeignKey(app => app.PatientID);
		}
	}
}
