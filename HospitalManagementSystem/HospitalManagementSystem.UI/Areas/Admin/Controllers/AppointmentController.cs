using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class AppointmentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public AppointmentController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var appointments = await _context.Appointments
				.Include(a => a.Doctor) // Lấy thông tin bác sĩ
				.Include(a => a.Patient) // Lấy thông tin bệnh nhân
				.Include(a => a.Room) // Lấy thông tin phòng
				.ToListAsync();
			return View(appointments);
		}
	}
}
