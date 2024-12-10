/*using HospitalManagementSystem.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Core.DTO
{
	public class RegisterDTO
	{
		[Required(ErrorMessage = "Username cannot be blank!")]
		public string PersonName { get; set; }


		[Required(ErrorMessage = "Email cannot be blank!")]
		[EmailAddress(ErrorMessage = "Email is not in correct format!")]
		[Remote(action: "IsEmailAlreadyRegistered", controller: "User", ErrorMessage = "Email already in use!")]
		public string Email { get; set; }


		[Required(ErrorMessage = "Phone cannot be blank!")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "Phone numbers must contain only numbers!")]
		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }


		[Required(ErrorMessage = "Password cannot be blank!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }


		[Required(ErrorMessage = "Comfirm Password cannot be blank!")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password and Confirm Password are not the same!")]
		public string ConfirmPassword { get; set; }

		public GenderOptions GenderType { get; set; }

		public UserTypeOptions UserType { get; set; } = UserTypeOptions.Admin;
	}
}
*/