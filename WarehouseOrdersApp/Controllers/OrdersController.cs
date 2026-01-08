using Microsoft.AspNetCore.Mvc;
using WarehouseOrdersApp.Data;
using WarehouseOrdersApp.Models;

namespace WarehouseOrdersApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly WarehouseContext _context;

        public OrdersController(WarehouseContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var order = new Order
            {
                CustomerName = model.CustomerName,
                OrderDate = model.OrderDate!.Value
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
