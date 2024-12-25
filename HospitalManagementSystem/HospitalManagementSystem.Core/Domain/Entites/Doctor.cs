using HospitalManagementSystem.Core.Domain.IndentityEntities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Doctor
	{
		[Key]
		public Guid DoctorID { get; set; }

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
		
		[StringLength (300)]
		public string? Address { get; set; }

		public Guid? DepartmentID { get; set; }

		[StringLength(10)]
		public string? Availability { get; set; }

		//AccountID
		public Guid? Id { get; set; }
		public virtual ApplicationUser? ApplicationUser { get; set; }

		[ForeignKey("DepartmentID")]
		public virtual Department? Department { get; set; }

		// 1 Doctor -> Many Treatments
		public virtual ICollection<Treatment>? Treatments { get; set; }

		// 1 Doctor -> Many Appointments
		public virtual ICollection<Appointment>? Appointments { get; set; }
		public override string ToString()
		{
			return $"Person ID: {DoctorID}, Person Name: {FirstName + LastName}, Date of Birth: {DateOfBirth?.ToString("MM/dd/yyyy")}, Gender: {Gender}, Address: {Address}";
		}
	}
}
