﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Intership.Models.RequestModels.Product
{
    public abstract class ManipulationProductModel
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price is required and it can`t be lower than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Product description is a required field.")]
        public string Description { get; set; }
    }
}