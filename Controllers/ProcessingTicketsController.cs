using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeafoodApp.Data;
using SeafoodApp.Models;

namespace SeafoodApp.Controllers
{
    public class ProcessingTicketsController : Controller
    {
        private readonly AppDbContext _context;

        public ProcessingTicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProcessingTickets
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProcessingTickets.Include(p => p.ProcessStep).Include(p => p.ProductionOrder);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProcessingTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processingTicket = await _context.ProcessingTickets
                .Include(p => p.ProcessStep)
                .Include(p => p.ProductionOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processingTicket == null)
            {
                return NotFound();
            }

            return View(processingTicket);
        }

        // GET: ProcessingTickets/Create
        public IActionResult Create()
        {
            ViewData["ProcessStepId"] = new SelectList(_context.ProcessSteps, "Id", "Id");
            ViewData["ProductionOrderId"] = new SelectList(_context.ProductionOrders, "Id", "Id");
            return View();
        }

        // POST: ProcessingTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,ProcessingDate,ProductionOrderId,ProcessStepId,Department,WorkerCount,DurationHours,IsCompleted,Note")] ProcessingTicket processingTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processingTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcessStepId"] = new SelectList(_context.ProcessSteps, "Id", "Id", processingTicket.ProcessStepId);
            ViewData["ProductionOrderId"] = new SelectList(_context.ProductionOrders, "Id", "Id", processingTicket.ProductionOrderId);
            return View(processingTicket);
        }

        // GET: ProcessingTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processingTicket = await _context.ProcessingTickets.FindAsync(id);
            if (processingTicket == null)
            {
                return NotFound();
            }
            ViewData["ProcessStepId"] = new SelectList(_context.ProcessSteps, "Id", "Id", processingTicket.ProcessStepId);
            ViewData["ProductionOrderId"] = new SelectList(_context.ProductionOrders, "Id", "Id", processingTicket.ProductionOrderId);
            return View(processingTicket);
        }

        // POST: ProcessingTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,ProcessingDate,ProductionOrderId,ProcessStepId,Department,WorkerCount,DurationHours,IsCompleted,Note")] ProcessingTicket processingTicket)
        {
            if (id != processingTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processingTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessingTicketExists(processingTicket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcessStepId"] = new SelectList(_context.ProcessSteps, "Id", "Id", processingTicket.ProcessStepId);
            ViewData["ProductionOrderId"] = new SelectList(_context.ProductionOrders, "Id", "Id", processingTicket.ProductionOrderId);
            return View(processingTicket);
        }

        // GET: ProcessingTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processingTicket = await _context.ProcessingTickets
                .Include(p => p.ProcessStep)
                .Include(p => p.ProductionOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processingTicket == null)
            {
                return NotFound();
            }

            return View(processingTicket);
        }

        // POST: ProcessingTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processingTicket = await _context.ProcessingTickets.FindAsync(id);
            if (processingTicket != null)
            {
                _context.ProcessingTickets.Remove(processingTicket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessingTicketExists(int id)
        {
            return _context.ProcessingTickets.Any(e => e.Id == id);
        }
    }
}
