using Microsoft.AspNetCore.Identity;

namespace Intership.Data.Entities
{
    public class User : IdentityUser
    {
        public string Login { get; set; }

        public string Password { get; set; }
        
        public Client Profile { get; set; }
    }
}