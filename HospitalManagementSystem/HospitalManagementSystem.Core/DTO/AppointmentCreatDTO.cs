using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.DTO
{
	public class AppointmentCreateDTO
	{
		public Guid DoctorID { get; set; }
		public string? DoctorName { get; set; }

		[Required]
		public Guid? PatientID { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime AppointmentDate { get; set; }

		[StringLength(200)]
		public string? Notes { get; set; }

		public Guid RoomID { get; set; }
	}
}
