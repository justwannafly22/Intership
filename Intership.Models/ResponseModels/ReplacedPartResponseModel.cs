using System;

namespace Intership.Models.ResponseModels
{
    /// <summary>
    /// Replaced part model to response to client
    /// </summary>
    public class ReplacedPartResponseModel
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public string AdvancedInfo { get; set; }
    }
}
