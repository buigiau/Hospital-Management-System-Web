using Entites;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Areas.Patients.Controllers
{
	[Area("Patient")]
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
			// Lấy ApplicationUserId từ thông tin đăng nhập
			var applicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(applicationUserId))
			{
				return Unauthorized(); // Người dùng chưa đăng nhập
			}

			// Tìm bệnh nhân liên kết với ApplicationUserId
			var patient = await _context.Patients
				.FirstOrDefaultAsync(p => p.ApplicationUser.Id == Guid.Parse(applicationUserId));

			if (patient == null)
			{
				return NotFound("Không tìm thấy thông tin bệnh nhân của bạn.");
			}

			// Lấy danh sách hóa đơn liên quan đến bệnh nhân
			var invoices = await _context.Invoices
				.Include(i => i.Treatment) // Bao gồm thông tin Treatment
				.Where(i => i.Treatment.PatientID == patient.PatientID) // Liên kết qua PatientID
				.Select(i => new InvoiceDTO // Chuyển đổi dữ liệu thành DTO
				{
					InvoiceID = i.InvoiceID,
					TreatmentID = i.TreatmentID,
					InvoiceDate = i.InvoiceDate,
					Amount = i.Amount,
					TreatmentTitle = i.Treatment.Title,
					PaymentStatus = i.PaymentStatus,
				})
				.ToListAsync();
			ViewData["PatientId"] = patient.PatientID;

			// Trả về View cùng dữ liệu
			return View(invoices);
		}

		[HttpPost]
		public async Task<IActionResult> PayInvoice(Guid invoiceId)
		{
			var invoice = await _context.Invoices.FindAsync(invoiceId);

			if (invoice == null)
			{
				return NotFound("Invoice not found.");
			}

			if (invoice.PaymentStatus == "Paid")
			{
				return BadRequest("Invoice is already paid.");
			}

			// Update payment status
			invoice.PaymentStatus = "Paid";
			_context.Invoices.Update(invoice);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

	}
}
