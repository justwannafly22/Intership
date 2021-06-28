using System;

namespace Intership.Models.RequestModels.RepairInfo
{
    public class UpdateRepairInfoModel : ManipulationRepairInfoModel
    {
        public Guid? StatusId { get; set; }
    }
}
