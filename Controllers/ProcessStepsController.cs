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
    public class ProcessStepsController : Controller
    {
        private readonly AppDbContext _context;

        public ProcessStepsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProcessSteps
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcessSteps.ToListAsync());
        }

        // GET: ProcessSteps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processStep = await _context.ProcessSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processStep == null)
            {
                return NotFound();
            }

            return View(processStep);
        }

        // GET: ProcessSteps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessSteps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,InputMaterial,OutputMaterial,Standard")] ProcessStep processStep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processStep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processStep);
        }

        // GET: ProcessSteps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processStep = await _context.ProcessSteps.FindAsync(id);
            if (processStep == null)
            {
                return NotFound();
            }
            return View(processStep);
        }

        // POST: ProcessSteps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,InputMaterial,OutputMaterial,Standard")] ProcessStep processStep)
        {
            if (id != processStep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processStep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessStepExists(processStep.Id))
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
            return View(processStep);
        }

        // GET: ProcessSteps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processStep = await _context.ProcessSteps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processStep == null)
            {
                return NotFound();
            }

            return View(processStep);
        }

        // POST: ProcessSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processStep = await _context.ProcessSteps.FindAsync(id);
            if (processStep != null)
            {
                _context.ProcessSteps.Remove(processStep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessStepExists(int id)
        {
            return _context.ProcessSteps.Any(e => e.Id == id);
        }
    }
}
