using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class StockEntryViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
