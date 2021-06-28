using System;

namespace Intership.Models.ResponseModels
{
    public class RepairInfoResponseModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public string StatusInfo { get; set; }
    }
}
