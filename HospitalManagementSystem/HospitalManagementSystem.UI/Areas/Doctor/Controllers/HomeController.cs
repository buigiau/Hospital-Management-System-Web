using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Doctor.Controllers
{
	[Area("Doctor")]
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
			var doctor = await _context.Doctors.Include(d => d.Department)
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == id);

			if (doctor == null)
				return NotFound();
			ViewBag.DoctorId = doctor.Id;
			return View(doctor);
		}
	}
}
