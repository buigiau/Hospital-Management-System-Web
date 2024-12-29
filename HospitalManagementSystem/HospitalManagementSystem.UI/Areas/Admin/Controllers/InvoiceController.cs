using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class InvoiceController : Controller
	{
		private readonly ApplicationDbContext _context;
		public InvoiceController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var invoices = await _context.Invoices
				.Include(i => i.Treatment)
				.ToListAsync();

			return View(invoices);
		}
	}
}
