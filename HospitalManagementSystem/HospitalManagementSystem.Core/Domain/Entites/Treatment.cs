using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Treatment
	{
		[Key]
		public Guid TreatmentID { get; set; }

		public Guid PatientID { get; set; }

		public Guid DoctorID { get; set; }

		[StringLength(100)]
		public string? Title { get; set; }

		[StringLength(500)]
		public string? TreatmentDetails { get; set; }

		public DateTime? TreatmentDate { get; set; }

		public DateTime? FollowUpDate { get; set; }

		[ForeignKey("DoctorID")]
		public virtual Doctor? Doctor { get; set; }

		[ForeignKey("PatientID")]
		public virtual Patient? Patient { get;	set; }

		// 1 Treatment -> Many Prescriptions
		public virtual ICollection<Prescription>? Prescriptions { get; set; }

		// 1 Treatment -> Many Invoices
		public virtual ICollection<Invoice>? Invoices { get; set; }
	}
}
