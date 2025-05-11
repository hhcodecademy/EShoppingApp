using Microsoft.AspNetCore.Identity;

namespace EShoppingApp.Entity
{
    public class AppUser:IdentityUser
    {
        public string LastLoginIpAdr { get; set; }
    }
}
