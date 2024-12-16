using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Appointment
	{
		public Guid AppointmentID { get; set; }

		public Guid DoctorID { get; set; }

		public Guid PatientID { get; set; }

		public DateTime AppointmentDate { get; set; }

		[StringLength(20)]
		public string? Status { get; set; }
		public Guid RoomID { get; set; }

		[StringLength(200)]
		public string? Notes { get; set; }

		[ForeignKey("DoctorID")]
		public virtual Doctor? Doctor { get; set; }

		[ForeignKey("PatientID")]
		public virtual Patient? Patient { get; set; }

		[ForeignKey("RoomID")]
		public virtual Room? Room { get; set; }
	}
}
