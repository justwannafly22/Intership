using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ReplacedPart
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("replaced_part_name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [Column("price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price is required and it can`t be lower than 0.")]
        public double Price { get; set; }

        [Column("replaced_part_count")]
        [Range(0, int.MaxValue, ErrorMessage = "Count is required and it can`t be lower than 0.")]
        public int Count { get; set; }

        [Column("advanced_info")]
        [Required(ErrorMessage = "Advanced info is a required field.")]
        [MaxLength(500, ErrorMessage = "Max length for AdvancedInfo is 500 characters.")]
        public string AdvancedInfo { get; set; }
        
        [ForeignKey(nameof(Repair))]
        public Guid RepairId { get; set; }
        public Repair Repair { get; set; }
        
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
