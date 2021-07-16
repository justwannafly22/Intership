using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Data.Entities
{
    public class Client
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("client_name")]
        [Required]
        public string Name { get; set; }

        [Column("client_surname")]
        [Required]
        public string Surname { get; set; }

        [Column("age")]
        [Range(0, 150)]
        [Required]
        public int Age { get; set; }

        [Column("contact_number")]
        [Required]
        public string ContactNumber { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }
        
        [Column("allow_email_notifications")]
        public bool AllowEmailNotification { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Repair> Repairs { get; set; }
    }
}
