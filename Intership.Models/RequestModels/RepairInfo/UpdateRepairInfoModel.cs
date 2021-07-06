using System;
using System.ComponentModel.DataAnnotations;

namespace Intership.Models.RequestModels.RepairInfo
{
    public class UpdateRepairInfoModel
    {
        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Advanced info is a required field.")]
        [MaxLength(500, ErrorMessage = "Max length for AdvancedInfo is 500 characters.")]
        public string AdvancedInfo { get; set; }

        [Required]
        public Guid StatusId { get; set; }
    }
}
