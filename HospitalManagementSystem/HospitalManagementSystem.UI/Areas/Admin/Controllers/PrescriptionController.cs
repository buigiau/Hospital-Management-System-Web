using Entites;
using HospitalManagementSystem.Core.Domain.Entites;
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

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}

			var prescription = await _context.Prescriptions
				.Include(p => p.Treatment)
				.FirstOrDefaultAsync(p => p.PresciptionID == id);

			if (prescription == null)
			{
				return NotFound();
			}

			// Lấy danh sách Treatment
			ViewBag.Treatments = await _context.Treatments
				.Select(t => new { t.TreatmentID, t.Title })
				.ToListAsync();

			return View(prescription);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, Prescription prescription)
		{
			if (id != prescription.PresciptionID)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(prescription);
			}

			try
			{
				_context.Update(prescription);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Prescriptions.Any(p => p.PresciptionID == id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}

			var prescription = await _context.Prescriptions
				.Include(p => p.Treatment)
				.FirstOrDefaultAsync(p => p.PresciptionID == id);

			if (prescription == null)
			{
				return NotFound();
			}

			return View(prescription);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var prescription = await _context.Prescriptions.FirstOrDefaultAsync(p => p.PresciptionID == id);
			if (prescription == null)
			{
				return NotFound();
			}

			try
			{
				_context.Prescriptions.Remove(prescription);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateException ex)
			{
				// Log lỗi nếu cần
				ModelState.AddModelError(string.Empty, "Unable to delete the prescription. Please try again later.");
				return View("Error", ex);
			}
		}
	}
}
