using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeafoodApp.Data;
using SeafoodApp.Models;

namespace SeafoodApp.Controllers
{
    public class ProductionOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public ProductionOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductionOrders
        public async Task<IActionResult> Index()
        {
            var list = await _context.ProductionOrders
                .Include(o => o.Details)
                .ToListAsync();
            return View(list);
        }

        // GET: ProductionOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.ProductionOrders
                .Include(o => o.Details)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();

            return View(order);
        }

        // GET: ProductionOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductionOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductionOrder productionOrder)
        {
            if (productionOrder.Details == null || !productionOrder.Details.Any())
            {
                ModelState.AddModelError("", "Cần nhập ít nhất 1 dòng chi tiết.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(productionOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productionOrder);
        }

        // GET: ProductionOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.ProductionOrders
                .Include(o => o.Details)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();

            return View(order);
        }

        // POST: ProductionOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductionOrder productionOrder)
        {
            if (id != productionOrder.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(productionOrder);

            // 1) Xóa tất cả chi tiết cũ và lưu ngay
            var oldDetails = _context.ProductionOrderDetails
                                     .Where(d => d.ProductionOrderId == id);
            _context.ProductionOrderDetails.RemoveRange(oldDetails);
            await _context.SaveChangesAsync();

            // 2) Thêm lại toàn bộ chi tiết mới (tất cả có Id=0 từ View)
            foreach (var d in productionOrder.Details)
            {
                d.ProductionOrderId = id;
            }
            _context.ProductionOrderDetails.AddRange(productionOrder.Details);

            // 3) Cập nhật lệnh chính
            _context.ProductionOrders.Update(productionOrder);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductionOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.ProductionOrders.FindAsync(id);
            if (order == null) return NotFound();

            return View(order);
        }

        // POST: ProductionOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Xóa chi tiết trước
            var details = _context.ProductionOrderDetails
                                  .Where(d => d.ProductionOrderId == id);
            _context.ProductionOrderDetails.RemoveRange(details);

            // Xóa lệnh chính
            var order = await _context.ProductionOrders.FindAsync(id);
            if (order != null)
            {
                _context.ProductionOrders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
