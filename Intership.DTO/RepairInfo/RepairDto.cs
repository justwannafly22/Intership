using System;
using System.Collections.Generic;
using System.Text;

namespace Intership.DTO.RepairInfo
{
    public class RepairDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
    }
}
