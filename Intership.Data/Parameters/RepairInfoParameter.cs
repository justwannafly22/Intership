using System;

namespace Intership.Data.Parameters
{
    public class RepairInfoParameter
    {
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public Guid StatusId { get; set; }
    }
}
