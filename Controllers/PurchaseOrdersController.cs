using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeafoodApp.Data;
using SeafoodApp.Helpers;
using SeafoodApp.Models;

namespace SeafoodApp.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public PurchaseOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrders
        public async Task<IActionResult> Index()
        {
            var list = await _context.PurchaseOrders
                .Include(po => po.Details)
                .Include(po => po.Supplier)
                .ToListAsync();

            return View(list);
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var purchaseOrder = await _context.PurchaseOrders
                .Include(po => po.Supplier)
                .Include(po => po.Details)
                .FirstOrDefaultAsync(po => po.Id == id.Value);

            if (purchaseOrder == null) return NotFound();
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            // Gán code tự động
            var lastCode = _context.PurchaseOrders
                                   .OrderByDescending(po => po.Code)
                                   .Select(po => po.Code)
                                   .FirstOrDefault();
            ViewBag.NewCode = CodeHelper.NextCode("PM-", lastCode);

            // Gán danh sách Suppliers cho dropdown nếu cần
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: PurchaseOrders/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder purchaseOrder)
        {
            // Sinh code
            var lastCode = _context.PurchaseOrders
                                   .OrderByDescending(po => po.Code)
                                   .Select(po => po.Code)
                                   .FirstOrDefault();
            purchaseOrder.Code = CodeHelper.NextCode("PM-", lastCode);

            // Loại bỏ detail rỗng
            if (purchaseOrder.Details != null)
            {
                purchaseOrder.Details = purchaseOrder.Details
                    .Where(d => d.Quantity > 0)
                    .ToList();

                // Sinh batch cho từng detail
                var lastLot = _context.PurchaseOrders
                                      .SelectMany(po => po.Details)
                                      .OrderByDescending(d => d.BatchNumber)
                                      .Select(d => d.BatchNumber)
                                      .FirstOrDefault();
                foreach (var d in purchaseOrder.Details)
                {
                    d.BatchNumber = CodeHelper.NextLot("LOT-", lastLot);
                    lastLot = d.BatchNumber;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var purchaseOrder = await _context.PurchaseOrders
                .Include(po => po.Details)
                .FirstOrDefaultAsync(po => po.Id == id.Value);

            if (purchaseOrder == null) return NotFound();

            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id) return NotFound();

            // Loại bỏ detail rỗng
            if (purchaseOrder.Details != null)
                purchaseOrder.Details = purchaseOrder.Details.Where(d => d.Quantity > 0).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PurchaseOrders.Any(po => po.Id == purchaseOrder.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var purchaseOrder = await _context.PurchaseOrders
                .Include(po => po.Supplier)
                .FirstOrDefaultAsync(po => po.Id == id.Value);
            if (purchaseOrder == null) return NotFound();

            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrders
                .Include(po => po.Details)
                .FirstOrDefaultAsync(po => po.Id == id);
            if (purchaseOrder != null)
            {
                _context.PurchaseOrders.Remove(purchaseOrder);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
