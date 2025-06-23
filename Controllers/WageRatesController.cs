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
    public class WageRatesController : Controller
    {
        private readonly AppDbContext _context;

        public WageRatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WageRates
        public async Task<IActionResult> Index()
        {
            return View(await _context.WageRates.ToListAsync());
        }

        // GET: WageRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wageRate = await _context.WageRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wageRate == null)
            {
                return NotFound();
            }

            return View(wageRate);
        }

        // GET: WageRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WageRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProcessStepName,Rate")] WageRate wageRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wageRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wageRate);
        }

        // GET: WageRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wageRate = await _context.WageRates.FindAsync(id);
            if (wageRate == null)
            {
                return NotFound();
            }
            return View(wageRate);
        }

        // POST: WageRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcessStepName,Rate")] WageRate wageRate)
        {
            if (id != wageRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wageRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WageRateExists(wageRate.Id))
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
            return View(wageRate);
        }

        // GET: WageRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wageRate = await _context.WageRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wageRate == null)
            {
                return NotFound();
            }

            return View(wageRate);
        }

        // POST: WageRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wageRate = await _context.WageRates.FindAsync(id);
            if (wageRate != null)
            {
                _context.WageRates.Remove(wageRate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WageRateExists(int id)
        {
            return _context.WageRates.Any(e => e.Id == id);
        }
    }
}
