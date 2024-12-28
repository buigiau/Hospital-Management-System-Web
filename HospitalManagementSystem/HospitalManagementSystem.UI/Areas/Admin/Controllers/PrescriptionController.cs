using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class PrescriptionController : Controller
	{
		private readonly ApplicationDbContext _context;
		public PrescriptionController(ApplicationDbContext context) 
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var prescriptions = await _context.Prescriptions
				.Include(p => p.Treatment)
				.ToListAsync();

			return View(prescriptions);
		}
	}
}
