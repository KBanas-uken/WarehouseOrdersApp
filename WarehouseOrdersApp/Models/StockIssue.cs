using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class StockIssue
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public DateTime IssueDate { get; set; }
    }
}
