using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.DTO
{
	public class PrescriptionDTO
	{
		public Guid PrescriptionID { get; set; }
		public string? MedicationName { get; set; }
		public int Dosage { get; set; }
		public string? Instruction { get; set; }
		public DateTime? TreatmentDate { get; set; }
		public string? PatientFullName { get; set; }
		public string? Title { get; set; }
	}
}
