using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models.Entities
{
    public class Client
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("client_name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [Column("client_surname")]
        [Required(ErrorMessage = "Surname is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Surname is 60 characters.")]
        public string Surname { get; set; }

        [Column("age")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Age is required and it can`t be lower than 0.")]
        public int? Age { get; set; }

        [Column("contact_number")]
        [Required(ErrorMessage = "Contact number is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for ContactNumber is 60 characters.")]
        public string ContactNumber { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Email is 60 characters.")]
        public string Email { get; set; }
        
        [Column("allow_email_notifications")]
        [Required(ErrorMessage = "ContactNumber is a required field.")]
        public bool AllowEmailNotification { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
