using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystem.Core.Domain.IndentityEntities
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public string? PersonName { get; set; }
	}
}
