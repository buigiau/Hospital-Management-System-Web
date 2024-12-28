using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.DTO
{
	public class AppointmentDTO
	{
		public Guid AppointmentID { get; set; }
		public DateTime AppointmentDate { get; set; }
		public string Status { get; set; }
		public string DoctorFullName { get; set; }
		public string PatientFullName { get; set; }

		public int RoomNumber { get; set; }
		public string? Notes {  get; set; }

		public Guid DoctorID { get; set; }
	}
}
