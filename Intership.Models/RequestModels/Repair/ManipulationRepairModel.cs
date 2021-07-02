﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Intership.Models.RequestModels.Repair
{
    public abstract class ManipulationRepairModel
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }
    }
}
