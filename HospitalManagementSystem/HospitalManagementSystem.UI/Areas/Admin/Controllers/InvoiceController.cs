using Entites;
using HospitalManagementSystem.Core.Domain.Entites;
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

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}

			// Truy xuất Invoice cùng với Treatment liên quan
			var invoice = await _context.Invoices
				.Include(i => i.Treatment) // Bao gồm thông tin Treatment
				.FirstOrDefaultAsync(i => i.InvoiceID == id);

			if (invoice == null)
			{
				return NotFound();
			}

			// Truyền Treatment Title qua ViewBag
			ViewBag.TreatmentTitle = invoice.Treatment?.Title;

			return View(invoice);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, Invoice invoice)
		{
			if (id != invoice.InvoiceID)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(invoice);
			}

			try
			{
				_context.Update(invoice);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Invoices.Any(i => i.InvoiceID == id))
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

			var invoice = await _context.Invoices
				.Include(i => i.Treatment)
				.FirstOrDefaultAsync(i => i.InvoiceID == id);

			if (invoice == null)
			{
				return NotFound();
			}

			return View(invoice);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.InvoiceID == id);
			if (invoice == null)
			{
				return NotFound();
			}

			try
			{
				_context.Invoices.Remove(invoice);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateException ex)
			{
				// Log lỗi nếu cần
				ModelState.AddModelError(string.Empty, "Unable to delete the invoice. Please try again later.");
				return View("Error", ex);
			}
		}
	}
}
