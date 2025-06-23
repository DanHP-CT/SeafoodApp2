using System;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var list = await _context.PurchaseOrders
                .Include(p => p.Supplier)
                .ToListAsync();
            return View(list);
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.PurchaseOrders
                .Include(p => p.Supplier)
                .Include(p => p.Details)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            ViewBag.SupplierList = new SelectList(_context.Suppliers, "Id", "Name");
            return View(new PurchaseOrder { Details = { new PurchaseOrderDetail() } });
        }

        // POST: PurchaseOrders/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder purchaseOrder)
        {
            if (string.IsNullOrWhiteSpace(purchaseOrder.Code))
                ModelState.AddModelError("Code", "Số phiếu không được để trống.");

            if (purchaseOrder.Details == null || !purchaseOrder.Details.Any())
                ModelState.AddModelError("", "Phải có ít nhất 1 dòng chi tiết.");

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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.PurchaseOrders
                .Include(p => p.Details)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (order == null) return NotFound();

            ViewBag.SupplierList = new SelectList(_context.Suppliers, "Id", "Name", order.SupplierId);
            return View(order);
        }

        // POST: PurchaseOrders/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id) return NotFound();
            if (string.IsNullOrWhiteSpace(purchaseOrder.Code))
                ModelState.AddModelError("Code", "Số phiếu không được để trống.");
            if (purchaseOrder.Details == null || !purchaseOrder.Details.Any())
                ModelState.AddModelError("", "Phải có ít nhất 1 dòng chi tiết.");

            if (!ModelState.IsValid)
            {
                ViewBag.SupplierList = new SelectList(_context.Suppliers, "Id", "Name", purchaseOrder.SupplierId);
                return View(purchaseOrder);
            }

            // Cập nhật: xóa hết detail cũ, rồi add lại
            var oldDetails = _context.PurchaseOrderDetails
                .Where(d => d.PurchaseOrderId == id);
            _context.PurchaseOrderDetails.RemoveRange(oldDetails);

            foreach (var d in purchaseOrder.Details)
                d.PurchaseOrderId = id;

            _context.PurchaseOrderDetails.AddRange(purchaseOrder.Details);

            // Cập nhật master
            _context.PurchaseOrders.Update(purchaseOrder);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.PurchaseOrders
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
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
