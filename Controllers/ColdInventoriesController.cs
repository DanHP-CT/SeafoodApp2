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
    public class ColdInventoriesController : Controller
    {
        private readonly AppDbContext _context;

        public ColdInventoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ColdInventories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ColdInventories.ToListAsync());
        }

        // GET: ColdInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldInventory = await _context.ColdInventories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coldInventory == null)
            {
                return NotFound();
            }

            return View(coldInventory);
        }

        // GET: ColdInventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColdInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LotCode,ProductName,ProductType,Size,QuantityIn,QuantityOut,Stock,InDate,OutDate,Note")] ColdInventory coldInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coldInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coldInventory);
        }

        // GET: ColdInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldInventory = await _context.ColdInventories.FindAsync(id);
            if (coldInventory == null)
            {
                return NotFound();
            }
            return View(coldInventory);
        }

        // POST: ColdInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LotCode,ProductName,ProductType,Size,QuantityIn,QuantityOut,Stock,InDate,OutDate,Note")] ColdInventory coldInventory)
        {
            if (id != coldInventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coldInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColdInventoryExists(coldInventory.Id))
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
            return View(coldInventory);
        }

        // GET: ColdInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldInventory = await _context.ColdInventories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coldInventory == null)
            {
                return NotFound();
            }

            return View(coldInventory);
        }

        // POST: ColdInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coldInventory = await _context.ColdInventories.FindAsync(id);
            if (coldInventory != null)
            {
                _context.ColdInventories.Remove(coldInventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColdInventoryExists(int id)
        {
            return _context.ColdInventories.Any(e => e.Id == id);
        }
    }
}
