using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WarehouseOrdersApp.Data;
using WarehouseOrdersApp.Models;

namespace WarehouseOrdersApp.Controllers
{
    public class StockController : Controller
    {
        private readonly WarehouseContext _context;

        public StockController(WarehouseContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult AddStock()
        {
            ViewBag.Products = new SelectList(
                _context.Products.ToList(),
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        public IActionResult AddStock(StockEntryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var product = _context.Products.Find(model.ProductId);
            if (product == null)
                return NotFound();

            product.StockQuantity += model.Quantity;

            _context.StockEntries.Add(new StockEntry
            {
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                EntryDate = DateTime.Now
            });

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult IssueStock()
        {
            ViewBag.Products = new SelectList(
                _context.Products,
                "Id",
                "Name"
            );

            ViewBag.Orders = new SelectList(
                _context.Orders
                    .Select(o => new
                    {
                        o.Id,
                        Display = $"Order #{o.Id} - {o.CustomerName} ({o.OrderDate:yyyy-MM-dd})"
                    })
                    .ToList(),
                "Id",
                "Display"
            );

            return View(new StockIssueViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult IssueStock(StockIssueViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Products = new SelectList(_context.Products, "Id", "Name");
                ViewBag.Orders = new SelectList(_context.Orders, "Id", "CustomerName");
                return View(model);
            }

            var product = _context.Products.Find(model.ProductId);
            if (product == null)
                return NotFound();

            if (product.StockQuantity < model.Quantity)
            {
                ModelState.AddModelError("", "Not enough stock in warehouse.");
                ViewBag.Products = new SelectList(_context.Products, "Id", "Name");
                ViewBag.Orders = new SelectList(_context.Orders, "Id", "CustomerName");
                return View(model);
            }

            product.StockQuantity -= model.Quantity;

            _context.StockIssues.Add(new StockIssue
            {
                ProductId = model.ProductId,
                OrderId = model.OrderId,
                Quantity = model.Quantity,
                IssueDate = DateTime.Now
            });

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}