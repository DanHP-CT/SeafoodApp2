using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeafoodApp.Data;
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
        public IActionResult Index()
        {
            var orders = _context.PurchaseOrders
                .Include(p => p.Supplier)
                .ToList();
            return View(orders);
        }

        // GET: PurchaseOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.PurchaseOrders
                .Include(p => p.Supplier)
                .Include(p => p.Details)
                .FirstOrDefault(m => m.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            ViewBag.SupplierList = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: PurchaseOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder purchaseOrder)
        {
            if (string.IsNullOrWhiteSpace(purchaseOrder.Code))
            {
                ModelState.AddModelError("Code", "Số phiếu không được để trống!");
            }
            if (ModelState.IsValid)
            {
                purchaseOrder.CreatedDate = DateTime.Now;
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SupplierList = new SelectList(_context.Suppliers, "Id", "Name", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.PurchaseOrders.Find(id);
            if (order == null) return NotFound();

            ViewBag.SupplierList = new SelectList(_context.Suppliers, "Id", "Name", order.SupplierId);
            return View(order);
        }

        // POST: PurchaseOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PurchaseOrders.Any(e => e.Id == purchaseOrder.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SupplierList = new SelectList(_context.Suppliers, "Id", "Name", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = _context.PurchaseOrders
                .Include(p => p.Supplier)
                .FirstOrDefault(m => m.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.PurchaseOrders.FindAsync(id);
            if (order != null)
            {
                _context.PurchaseOrders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
