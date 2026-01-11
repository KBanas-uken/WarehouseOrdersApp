using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WarehouseOrdersApp.Data;

namespace WarehouseOrdersApp.Controllers
{
    public class StockController : Controller
    {
        private readonly WarehouseContext _context;

        public StockController(WarehouseContext context)
        {
            _context = context;
        }

        public IActionResult AddStock()
        {
            ViewBag.Products = new SelectList(
                _context.Products.ToList(),
                "Id",
                "Name"
            );

            return View();
        }
    }
}
