using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "User,Admin")]
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();

            var model = new OrderCreateViewModel
            {
                OrderDate = DateTime.Today,
                Items = new List<OrderItemCreateViewModel>
                {
                    new OrderItemCreateViewModel()
                }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Products = _context.Products.ToList();
                return View(model);
            }

            var order = new Order
            {
                CustomerName = model.CustomerName,
                OrderDate = model.OrderDate!.Value
            };

            foreach (var item in model.Items)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
