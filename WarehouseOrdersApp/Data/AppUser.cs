using Microsoft.AspNetCore.Identity;

namespace WarehouseOrdersApp.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
