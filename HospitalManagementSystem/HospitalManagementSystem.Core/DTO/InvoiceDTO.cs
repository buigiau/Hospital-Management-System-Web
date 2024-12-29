using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.DTO
{
	public class InvoiceDTO
	{
		public Guid InvoiceID { get; set; }

		public Guid TreatmentID { get; set; }

		public double Amount { get; set; }

		public string? PaymentStatus { get; set; }

		public DateTime? InvoiceDate { get; set; }

		public string TreatmentTitle { get; set; }
	}
}
