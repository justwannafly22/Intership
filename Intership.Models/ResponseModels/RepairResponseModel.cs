using System;

namespace Intership.Models.ResponseModels
{
    /// <summary>
    /// Repair model to response to client
    /// </summary>
    public class RepairResponseModel
    {
        #region Taked from Repair
        public Guid Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Taked from RepairInfo
        public Guid RepairInfoId { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        #endregion

        #region Taked from Status
        public string StatusInfo { get; set; }
        #endregion
    }
}
