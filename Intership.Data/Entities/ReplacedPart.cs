using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Data.Entities
{
    public class ReplacedPart
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("replaced_part_name")]
        [Required]
        [MaxLength]
        public string Name { get; set; }

        [Column("price")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Column("replaced_part_count")]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        [Column("advanced_info")]
        [Required]
        [MaxLength(500)]
        public string AdvancedInfo { get; set; }

        [ForeignKey(nameof(Repair))]
        [Column("repair_id")]
        public Guid RepairId { get; set; }
        public Repair Repair { get; set; }
        
        [ForeignKey(nameof(Product))]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
