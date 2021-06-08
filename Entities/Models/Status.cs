using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Status
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("status_info")]
        [Required(ErrorMessage = "Status info is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for StatusInfo is 500 characters.")]
        public string StatusInfo { get; set; }

        public ICollection<RepairInfo> RepairsInfo { get; set; }
    }
}
