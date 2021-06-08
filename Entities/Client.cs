using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Client
    {
        public Guid Id { get; set; }

        [Column("client_name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [Column("client_surname")]
        [Required(ErrorMessage = "Surname is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Surname is 60 characters.")]
        public string Surname { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Age is required and it can`t be lower than 0.")]
        public int Age { get; set; }

        [Column("contact_number")]
        [Required(ErrorMessage = "ContactNumber is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for ContactNumber is 60 characters.")]
        public string ContactNumber { get; set; }
    }
}
