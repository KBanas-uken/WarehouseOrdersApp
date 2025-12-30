using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

}
