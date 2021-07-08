using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Data.Entities
{
    public class RepairInfo
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }
        
        [Column("repair_date")]
        [Required]
        public DateTime Date { get; set; }
        
        [Column("advanced_info")]
        [Required]
        [MaxLength(500)]
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
