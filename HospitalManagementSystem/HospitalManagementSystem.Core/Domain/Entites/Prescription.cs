using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Prescription
	{
		[Key]
		public Guid PresciptionID { get; set; }

		public Guid TreatmentID { get; set; }

		[StringLength (100)]
		public string? MedicationName { get; set; }

		public int Dosage { get; set; }

		[StringLength (200)]
		public string? Instruction { get; set; }

		[ForeignKey("TreatmentID")]
		public virtual Treatment? Treatment { get; set; }
	}
}
