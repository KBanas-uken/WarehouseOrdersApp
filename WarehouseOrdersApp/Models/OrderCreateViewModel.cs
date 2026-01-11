using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class OrderItemCreateViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

    public class OrderCreateViewModel
    {
        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public DateTime? OrderDate { get; set; }

        // Products assigned to the order
        public List<OrderItemCreateViewModel> Items { get; set; }
            = new();
    }
}
