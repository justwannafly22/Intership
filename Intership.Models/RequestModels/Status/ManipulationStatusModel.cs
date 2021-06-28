using System.ComponentModel.DataAnnotations;

namespace Intership.Models.RequestModels.Status
{
    public abstract class ManipulationStatusModel
    {
        [Required(ErrorMessage = "Advanced info is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for AdvancedInfo is 500 characters.")]
        public string StatusInfo { get; set; }
    }
}
