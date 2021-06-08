using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class RepairInfo
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("repair_date")]
        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }
        
        [Column("advanced_info")]
        [Required(ErrorMessage = "Advanced info is a required field.")]
        [MaxLength(500, ErrorMessage = "Max length for AdvancedInfo is 500 characters.")]
        public string AdvancedInfo { get; set; }
        
        [ForeignKey(nameof(Status))]
        [Column("status_id")]
        public Guid StatusId { get; set; }
        public Status Status { get; set; }

        [ForeignKey(nameof(Repair))]
        [Column("repair_id")]
        public Guid RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}
