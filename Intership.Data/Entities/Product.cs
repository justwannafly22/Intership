using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Data.Entities
{
    public class Product
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("product_name")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Column("price")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        
        [Column("product_description")]
        [Required]
        public string Description { get; set; }
        
        public ICollection<ReplacedPart> ReplacedParts { get; set; }
    }
}
