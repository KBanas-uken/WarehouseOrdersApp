using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseOrdersApp.Data;
using WarehouseOrdersApp.Models;

namespace WarehouseOrdersApp.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersApiController : Controller
    {
        private readonly WarehouseContext _context;

        public OrdersApiController(WarehouseContext context)
        {
            _context = context;
        }

        //READ
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Orders.Include(o => o.Items));
        }

        //READ by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == id);

            if(order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Order order)
        {
            if (id != order.Id) return BadRequest();

            _context.Orders.Update(order);
            _context.SaveChanges();
            return NoContent();
        }

       [HttpDelete("{id}")]
       public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);

            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
