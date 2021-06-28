using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Data.Entities
{
    public class Repair
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [ForeignKey(nameof(RepairInfo))]
        [Column("repairinfo_id")]
        public Guid RepairInfoId { get; set; }
        public RepairInfo RepairInfo { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<ReplacedPart> ReplacedParts { get; set; }
    }
}
