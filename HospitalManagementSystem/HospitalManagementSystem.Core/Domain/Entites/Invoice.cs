using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Invoice
	{
		[Key]
		public Guid InvoiceID { get; set; }

		public Guid TreatmentID { get; set; }

		public double Amount { get; set; }

		[StringLength(20)]
		public string? PaymentStatus { get; set; }

		public DateTime? InvoiceDate { get; set; }

		[ForeignKey("TreatmentID")]
		public virtual Treatment? Treatment { get; set; }
	}
}
