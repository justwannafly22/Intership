using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Intership.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public Client Profile { get; set; }
    }
}