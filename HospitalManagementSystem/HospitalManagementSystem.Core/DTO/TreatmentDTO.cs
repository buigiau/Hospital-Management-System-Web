using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.DTO
{
	public class TreatmentDTO
	{
		public Guid TreatmentID { get; set; }
		public DateTime? TreatmentDate { get; set; }
		public string TreatmentDetail { get; set;}

		public string PatientFullName { get; set;}

		public string DoctorFullName { get; set; }

		public string TreatmentTitle { get; set;}

		public DateTime? FollowUpDate { get; set; }
	}
}
