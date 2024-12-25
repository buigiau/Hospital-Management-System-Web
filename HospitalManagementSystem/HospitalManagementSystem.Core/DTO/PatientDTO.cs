using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.DTO
{
	public class PatientDTO
	{
		public Guid PatientID { get; set; }

		[Required(ErrorMessage ="First Name can not be blank!")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "First Name can not be blank!")]
		public string? LastName { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public GenderOptions? Gender { get; set; }

		[Required(ErrorMessage = "Email can not be blank!")]
		[EmailAddress(ErrorMessage = "Email is not in correct format!")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Phone cannot be blank!")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Phone numbers should contain only numbers!")]
		[DataType(DataType.PhoneNumber)]
		public string? PhoneNumber { get; set; }

		[Required(ErrorMessage = "Address can not be blank!")]
		public string? Address { get; set; }

		public int Appointment {  get; set; }
	}
}
