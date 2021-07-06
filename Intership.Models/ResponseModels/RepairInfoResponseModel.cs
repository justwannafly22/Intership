using System;

namespace Intership.Models.ResponseModels
{
    /// <summary>
    /// Repair info model to response to client
    /// </summary>
    public class RepairInfoResponseModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public string StatusInfo { get; set; }
    }
}
