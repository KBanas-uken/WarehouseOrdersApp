using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
