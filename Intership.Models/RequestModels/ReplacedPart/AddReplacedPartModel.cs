using System;
using System.ComponentModel.DataAnnotations;

namespace Intership.Models.RequestModels.ReplacedPart
{
    public class AddReplacedPartModel
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price is required and it can`t be lower than 0.")]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Count is required and it can`t be lower than 0.")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Advanced info is a required field.")]
        [MaxLength(500, ErrorMessage = "Max length for AdvancedInfo is 500 characters.")]
        public string AdvancedInfo { get; set; }

        [Required]
        public Guid RepairId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
