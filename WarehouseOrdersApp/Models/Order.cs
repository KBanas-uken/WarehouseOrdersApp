using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required, StringLength(100)]
        public required string CustomerName { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

}
