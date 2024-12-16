using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Room
	{
		public Guid RoomID { get; set; }

		public int RoomNumber { get; set; }

		public Guid DepartmentID { get; set; }

		public int Capacity { get; set; }

		[StringLength(100)]
		public string? RoomType { get; set; } //Ex: Rest Room, Meeting Room, Dining Room, Doctor Office,....
		
		[ForeignKey("DepartmentID")]
		public virtual Department? Department { get; set; }

		// 1 Room -> Many Appointments
		public virtual ICollection<Appointment>? Appointments { get; set; }
	}
}
