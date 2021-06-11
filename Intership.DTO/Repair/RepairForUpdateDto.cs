using System;
using System.Collections.Generic;
using System.Text;

namespace Intership.DTO.Repair
{
    public class RepairForUpdateDto : RepairForManipulationDto
    {
        public Guid? StatusId { get; set; }
    }
}
