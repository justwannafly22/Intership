using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Data.Entities
{
    public class Status
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }
        
        [Column("status_info")]
        [Required]
        [MaxLength(60)]
        public string StatusInfo { get; set; }

        public ICollection<RepairInfo> RepairsInfo { get; set; }
    }
}
