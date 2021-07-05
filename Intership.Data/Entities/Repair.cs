using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Data.Entities
{
    public class Repair
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [ForeignKey(nameof(RepairInfo))]
        [Column("repairinfo_id")]
        public Guid RepairInfoId { get; set; }
        public RepairInfo RepairInfo { get; set; }

        [ForeignKey(nameof(Client))]
        [Column("client_id")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<ReplacedPart> ReplacedParts { get; set; }
    }
}
