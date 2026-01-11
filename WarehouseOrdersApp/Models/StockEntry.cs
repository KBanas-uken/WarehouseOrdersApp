using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class StockEntry
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
