using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Domain.Entites
{
	public class Department
	{
		public Guid DepartmentID { get; set; }
		[StringLength(100)]
		public string? Name { get; set; }
		[StringLength(500)]
		public string? Description { get; set; }

		// 1 Department -> Many Doctors
		public virtual ICollection<Doctor>? Doctors { get; set; }

		// 1 Department -> Many Rooms
		public virtual ICollection<Room>? Rooms { get; set; }
	}
}
