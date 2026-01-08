namespace WarehouseOrdersApp.Models
{
    public class OrderCreateViewModel
    {
        
        public required string CustomerName { get; set; } = string.Empty;

        public required DateTime? OrderDate { get; set; }
    }
}
