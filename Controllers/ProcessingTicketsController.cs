using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeafoodApp.Data;
using SeafoodApp.Models;

namespace SeafoodApp.Controllers
{
    public class ProcessingTicketsController : Controller
    {
        private readonly AppDbContext _context;
        public ProcessingTicketsController(AppDbContext context)
            => _context = context;

        // GET: /ProcessingTickets
        public async Task<IActionResult> Index()
        {
            var list = await _context.ProcessingTickets
                .OrderByDescending(x => x.ProcessingDate)
                .ToListAsync();
            return View(list);
        }

        // GET: /ProcessingTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var ticket = await _context.ProcessingTickets
                .Include(x => x.InputDetails)
                .Include(x => x.OutputDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        // GET: /ProcessingTickets/Create
        public IActionResult Create()
        {
            return View(new ProcessingTicket());
        }

        // POST: /ProcessingTickets/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessingTicket ticket)
        {
            // lọc chi tiết trống
            ticket.InputDetails = ticket.InputDetails
                .Where(d => !string.IsNullOrWhiteSpace(d.MaterialName))
                .ToList();
            ticket.OutputDetails = ticket.OutputDetails
                .Where(d => !string.IsNullOrWhiteSpace(d.MaterialName))
                .ToList();

            if (!ModelState.IsValid) return View(ticket);

            // tự sinh mã phiếu theo format LSX-xxx-yy
            // (bạn có thể thay logic này bằng service)
            var count = await _context.ProcessingTickets.CountAsync() + 1;
            ticket.Code = $"LSX-{count:000}-{ticket.ProcessStepId:00}";

            _context.ProcessingTickets.Add(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /ProcessingTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var ticket = await _context.ProcessingTickets
                .Include(x => x.InputDetails)
                .Include(x => x.OutputDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        // POST: /ProcessingTickets/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcessingTicket ticket)
        {
            if (id != ticket.Id) return NotFound();

            ticket.InputDetails = ticket.InputDetails
                .Where(d => !string.IsNullOrWhiteSpace(d.MaterialName))
                .ToList();
            ticket.OutputDetails = ticket.OutputDetails
                .Where(d => !string.IsNullOrWhiteSpace(d.MaterialName))
                .ToList();

            if (!ModelState.IsValid) return View(ticket);

            // xoá cũ, thêm mới
            _context.ProcessingTicketInputDetails
                .RemoveRange(_context.ProcessingTicketInputDetails.Where(d => d.ProcessingTicketId == id));
            _context.ProcessingTicketOutputDetails
                .RemoveRange(_context.ProcessingTicketOutputDetails.Where(d => d.ProcessingTicketId == id));

            _context.Update(ticket);
            _context.ProcessingTicketInputDetails.AddRange(ticket.InputDetails);
            _context.ProcessingTicketOutputDetails.AddRange(ticket.OutputDetails);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /ProcessingTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var ticket = await _context.ProcessingTickets.FindAsync(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        // POST: /ProcessingTickets/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.ProcessingTickets.FindAsync(id);
            if (ticket != null)
            {
                _context.ProcessingTicketInputDetails.RemoveRange(
                    _context.ProcessingTicketInputDetails.Where(d => d.ProcessingTicketId == id));
                _context.ProcessingTicketOutputDetails.RemoveRange(
                    _context.ProcessingTicketOutputDetails.Where(d => d.ProcessingTicketId == id));
                _context.ProcessingTickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
