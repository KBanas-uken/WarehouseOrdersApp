using System.ComponentModel.DataAnnotations;

namespace WarehouseOrdersApp.Models
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Please insert the product's name.")]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
