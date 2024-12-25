using HospitalManagementSystem.Core.Domain.IndentityEntities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Patient
	{
		public Guid PatientID { get; set; }
		
		[StringLength(100)]
		public string? FirstName { get; set; }

		[StringLength(100)]
		public string? LastName { get; set; }
		
		public DateTime? DateOfBirth { get; set; }
		
		[StringLength(10)]
		public GenderOptions? Gender { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		[Phone]
		public string? PhoneNumber { get; set; }

		[StringLength(300)]
		public string? Address { get; set; }


		//AccountID
		public Guid Id { get; set; }
		public virtual ApplicationUser? ApplicationUser { get; set; }

		// 1 Patient -> Many Treatments
		public virtual ICollection<Treatment>? Treatments { get; set; }

		// 1 Patient -> Many Appointments
		public virtual ICollection<Appointment>? Appointments { get; set; }
		public override string ToString()
		{
			return $"Person ID: {PatientID}, Person Name: {FirstName + LastName}, Date of Birth: {DateOfBirth?.ToString("MM/dd/yyyy")}, Gender: {Gender}, Address: {Address}";
		}
	}
}
