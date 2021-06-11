using Intership.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intership.DTO.Repair
{
    public class RepairDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public string Status { get; set; }
        public Guid RepairInfoId { get; set; }
        public ICollection<ReplacedPart> ReplacedParts { get; set; }
    }
}
