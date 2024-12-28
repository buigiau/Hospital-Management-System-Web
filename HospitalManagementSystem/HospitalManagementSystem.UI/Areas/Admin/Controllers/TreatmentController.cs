using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class TreatmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public TreatmentController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var treatments = await _context.Treatments
				.Include(t => t.Doctor)
				.Include(t => t.Patient)
				.ToListAsync();

			return View(treatments);
		}
	}
}
