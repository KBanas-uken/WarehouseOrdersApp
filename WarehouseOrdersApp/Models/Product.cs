using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        /*public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }*/

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
