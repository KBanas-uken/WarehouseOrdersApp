using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseOrdersApp.Data;
using WarehouseOrdersApp.Models;

namespace WarehouseOrdersApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WarehouseContext _context;

        public ProductsController(WarehouseContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var product = new Product
            {
                Name = model.Name,
                StockQuantity = 0
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
