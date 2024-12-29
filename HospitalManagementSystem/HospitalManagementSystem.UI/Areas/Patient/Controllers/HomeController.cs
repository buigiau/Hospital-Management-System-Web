using Entites;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Patients.Controllers
{
	[Area("Patient")]
	[Authorize]
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(Guid id)
		{
			var patient = await _context.Patients
				.Include(p => p.Appointments)
				.ThenInclude(a => a.Doctor) 
				.ThenInclude(d => d.Department)
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == id);

			if (patient == null)
				return NotFound();

			return View(patient);
		}
	}
}
