using System;

namespace Intership.Models.RequestModels.ReplacedPart
{
    public class AddReplacedPartModel
    {
        public Guid RepairId { get; set; }
        public Guid ProductId { get; set; }
    }
}
