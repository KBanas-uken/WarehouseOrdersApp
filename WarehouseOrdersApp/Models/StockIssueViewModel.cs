using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class StockIssueViewModel
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
